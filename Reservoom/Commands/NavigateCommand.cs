using ReservoomClassLibrary.Models;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly MyNavigationService _navigationService;
        public NavigateCommand(MyNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
 