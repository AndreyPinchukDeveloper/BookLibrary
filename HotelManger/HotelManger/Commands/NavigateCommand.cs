using HotelManger.Services;
using HotelManger.ViewModels;

namespace HotelManger.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly MyNavigationService<TViewModel> _navigationService;
        public NavigateCommand(MyNavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
