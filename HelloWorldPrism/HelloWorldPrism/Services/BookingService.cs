using HelloWorldPrism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HelloWorldPrism.Services
{
    public class BookingService
    {
        private const string baseUrl = "http://bookingfree.azurewebsites.net/api/booking";

        /// <summary>
        /// Get a booking from the ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>A booking with the ID</returns>
        public async System.Threading.Tasks.Task<Booking> GetBookingAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(baseUrl + id.ToString());

                if (string.IsNullOrWhiteSpace(result)) return null;

                var booking = JsonConvert.DeserializeObject<Booking>(result);

                return booking;
            }
        }

        /// <summary>
        /// Get all bookings
        /// </summary>
        /// <returns>List of all bookings</returns>
        public async System.Threading.Tasks.Task<List<Booking>> GetAllBookingsAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(baseUrl);

                if (string.IsNullOrWhiteSpace(result)) return null;

                var bookings = JsonConvert.DeserializeObject<List<Booking>>(result);

                return bookings;
            }
        }

        /// <summary>
        /// Create a booking
        /// </summary>
        /// <param name="name"></param>
        public void CreateBooking(string name)
        {
            using (var client = new HttpClient())
            {
                //TODO
            }
        }
    }
}
