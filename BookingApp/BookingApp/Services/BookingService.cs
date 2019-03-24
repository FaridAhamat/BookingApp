using BookingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BookingApp.Services
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
        /// Move the booking to next status
        /// </summary>
        /// <param name="id">Id of the booking</param>
        /// <param name="currentStatus">Current status of the booking</param>
        public async System.Threading.Tasks.Task MoveBookingToNextAsync(int id, short currentStatus)
        {
            using (var client = new HttpClient())
            {
                var jsonContent = new Dictionary<string, string>();
                jsonContent.Add("op", "replace");
                jsonContent.Add("path", "BookingStatus");
                jsonContent.Add("value", (currentStatus + 1).ToString());

                string jsonString = "[" + JsonConvert.SerializeObject(jsonContent, Formatting.Indented) + "]";

                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var httpRequest = new HttpRequestMessage(new HttpMethod("PATCH"), baseUrl + "/" + id)
                {
                    Content = httpContent,
                };

                await client.SendAsync(httpRequest);
            }
        }

        /// <summary>
        /// Create a booking
        /// </summary>
        /// <param name="customerId">The Id of the customer</param>
        public async System.Threading.Tasks.Task<bool> CreateBookingAsync(int customerId)
        {
            using (var client = new HttpClient())
            {
                var booking = new Booking { CustomerId = customerId };

                var response = await client.PostAsJsonAsync(baseUrl, booking);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
