using HotelManger.Services;

namespace HotelManger.Commands
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
