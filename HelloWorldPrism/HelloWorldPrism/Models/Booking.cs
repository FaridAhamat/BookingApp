using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldPrism.Models
{
    public class Booking : BindableBase
    {
        private int id;
        private int customerId;
        private BookingStatus bookingStatus;

        public int Id
        {
            get;set;
            //get => id;
            //set => SetProperty(ref id, value);
        }

        public int CustomerId
        {
            get;set;
            //get => customerId;
            //set => SetProperty(ref customerId, value);
        }

        public BookingStatus BookingStatus { get; set; }
    }

    public enum BookingStatus
    {
        New = 0,
        CheckedIn = 1,
        CheckedOut = 2,
    }
}
