using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorldPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand navigateCustomerManagement;
        private DelegateCommand navigateBookingManagement;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Sample Booking App";
        }

        public DelegateCommand NavigateCustomerManagement => 
            navigateCustomerManagement ?? (navigateCustomerManagement = new DelegateCommand(ExecuteNavigateCustManagement));

        public DelegateCommand NavigateBookingManagement =>
            navigateBookingManagement ?? (navigateBookingManagement = new DelegateCommand(ExecuteNavigateBookingManagement));

        private async void ExecuteNavigateBookingManagement()
        {
            await NavigationService.NavigateAsync("BookingManagement");
        }

        private async void ExecuteNavigateCustManagement()
        {
            await NavigationService.NavigateAsync("CustomerManagement");
        }
    }
}
