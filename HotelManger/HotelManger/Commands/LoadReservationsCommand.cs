using HotelManger.Models;
using HotelManger.Stores;
using HotelManger.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManger.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly HotelStore _hotelStore;

        public LoadReservationsCommand(ReservationListingViewModel reservationListingViewModel, HotelStore hotelStore)//check here if something came up
        {
            _viewModel = reservationListingViewModel;
            _hotelStore = hotelStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ErrorMessage = string.Empty;
            _viewModel.IsLoading = true;

            try
            {
                await _hotelStore.Load();
                
                _viewModel.UpdateReservations(_hotelStore.Reservations);
            }
            catch (Exception)
            {

                _viewModel.ErrorMessage = "Failed to load reservations.";
            }
            _viewModel.IsLoading = false;
        }
    }
}
