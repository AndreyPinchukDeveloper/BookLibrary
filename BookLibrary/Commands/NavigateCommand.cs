using ApplicationClassLibrary.Models;
using BookLibrary.Services;
using BookLibrary.Stores;
using BookLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Commands
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
 