using HelloWorldPrism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HelloWorldPrism.Services
{
    public class CustomerService
    {
        private const string baseUrl = "http://bookingfree.azurewebsites.net/api/customer";
        //private const string baseUrl = "http://api.opendota.com/api/players/9999";

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

        public void CreateCustomer(string name)
        {
            using (var client = new HttpClient())
            {
            }
        }
    }
}
