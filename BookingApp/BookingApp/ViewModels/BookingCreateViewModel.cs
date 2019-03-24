using BookingApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.ViewModels
{
    public class BookingCreateViewModel : ViewModelBase
    {
        private BookingService bookingService;
        private DelegateCommand bookingCreate;

        public DelegateCommand BookingCreate
            => bookingCreate ?? (bookingCreate = new DelegateCommand(ExecuteCustomerCreateAsync));

        public int CustomerId { get; set; }

        public BookingCreateViewModel(BookingService bookingService, INavigationService navigationService) : base(navigationService)
        {
            this.bookingService = bookingService;
        }

        private async void ExecuteCustomerCreateAsync()
        {
            var success = await bookingService.CreateBookingAsync(CustomerId);

            if (success) await NavigationService.GoBackAsync();
        }
    }
}
