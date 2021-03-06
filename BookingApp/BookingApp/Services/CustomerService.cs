﻿using BookingApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace BookingApp.Services
{
    public class CustomerService
    {
        private const string baseUrl = "http://bookingfree.azurewebsites.net/api/customer";

        /// <summary>
        /// Get a customer from the ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>A customer with the ID</returns>
        public async System.Threading.Tasks.Task<Customer> GetCustomerAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(baseUrl + id.ToString());

                if (string.IsNullOrWhiteSpace(result)) return null;

                var customer = JsonConvert.DeserializeObject<Customer>(result);

                return customer;
            }
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        public async System.Threading.Tasks.Task<List<Customer>> GetAllCustomersAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(baseUrl);

                if (string.IsNullOrWhiteSpace(result)) return null;

                var customers = JsonConvert.DeserializeObject<List<Customer>>(result);

                return customers;
            }
        }

        /// <summary>
        /// Create a customer
        /// </summary>
        /// <param name="name">The name of the customer</param>
        public async System.Threading.Tasks.Task CreateCustomerAsync(string name)
        {
            using (var client = new HttpClient())
            {
                var customer = new Customer { Name = name, };

                await client.PostAsJsonAsync(baseUrl, customer);
            }
        }
    }
}
