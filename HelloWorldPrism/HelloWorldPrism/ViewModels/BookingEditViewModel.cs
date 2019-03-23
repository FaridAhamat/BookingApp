using HelloWorldPrism.Models;
using HelloWorldPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HelloWorldPrism.ViewModels
{
    public class BookingEditViewModel : ViewModelBase
    {
        private Booking booking;
        private DelegateCommand moveNext;
        private readonly BookingService bookingService;

        public Booking Booking
        {
            get => booking;
            set => SetProperty(ref booking, value);
        }

        public DelegateCommand MoveNext
            => moveNext ?? (moveNext = new DelegateCommand(ExecuteMoveNextAsync));

        public BookingEditViewModel(BookingService bookingService, INavigationService navigationService) : base(navigationService)
        {
            this.bookingService = bookingService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Booking = parameters.GetValue<Booking>("booking");
        }

        private async void ExecuteMoveNextAsync()
        {
            if (Booking != null)
            {
                if (Booking.BookingStatus != BookingStatus.CheckedOut)
                {
                    await bookingService.MoveBookingToNextAsync(Booking.Id, (short)Booking.BookingStatus);
                }
                
                await NavigationService.GoBackAsync();
            }
        }
    }
}
