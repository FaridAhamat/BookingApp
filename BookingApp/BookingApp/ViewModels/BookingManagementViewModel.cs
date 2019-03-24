using BookingApp.Models;
using BookingApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.ViewModels
{
	public class BookingManagementViewModel : ViewModelBase
	{
        private readonly BookingService bookingService;
        private ObservableCollection<Booking> bookings;
        private DelegateCommand<Booking> navigateBookingEdit;
        private DelegateCommand navigateBookingCreate;

        public ObservableCollection<Booking> Bookings
        {
            get { return bookings; }
            set { SetProperty(ref bookings, value); }
        }

        public DelegateCommand NavigateBookingCreate =>
            navigateBookingCreate ?? (navigateBookingCreate = new DelegateCommand(ExecuteNavigateBookingCreateAsync));

        public DelegateCommand<Booking> NavigateBookingEdit =>
            navigateBookingEdit ?? (navigateBookingEdit = new DelegateCommand<Booking>(ExecuteNavigateBookingEditAsync));

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

        private async void ExecuteNavigateBookingEditAsync(Booking booking)
        {
            var param = new NavigationParameters();
            param.Add("booking", booking);

            await NavigationService.NavigateAsync("BookingEdit", param);
        }

        private async void ExecuteNavigateBookingCreateAsync()
        {
            await NavigationService.NavigateAsync("BookingCreate");
        }
    }
}
