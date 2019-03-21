using HelloWorldPrism.Models;
using HelloWorldPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldPrism.ViewModels
{
	public class BookingManagementViewModel : ViewModelBase
	{
        private readonly BookingService bookingService;
        private ObservableCollection<Booking> bookings;

        public ObservableCollection<Booking> Bookings
        {
            get { return bookings; }
            set { SetProperty(ref bookings, value); }
        }

        public BookingManagementViewModel(INavigationService navigationService, BookingService bookingService) : base(navigationService)
        {
            this.bookingService = bookingService;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var bookings = await bookingService.GetAllBookingsAsync();

                Bookings = new ObservableCollection<Booking>(bookings);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading data in: {ex}");
            }
        }
    }
}
