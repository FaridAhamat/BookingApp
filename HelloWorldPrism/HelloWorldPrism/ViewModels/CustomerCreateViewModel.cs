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
    public class CustomerCreateViewModel : ViewModelBase
    {
        private readonly CustomerService customerService;
        private DelegateCommand<string> customerCreate;

        public DelegateCommand<string> CustomerCreate
            => customerCreate ?? (customerCreate = new DelegateCommand<string>(ExecuteCustomerCreateAsync));

        public bool IsEnabled = true;

        public string CustomerName { get; set; }

        public CustomerCreateViewModel(CustomerService customerService, INavigationService navigationService) : base(navigationService)
        {
            this.customerService = customerService;
        }

        private async void ExecuteCustomerCreateAsync(string customerName)
        {
            await customerService.CreateCustomerAsync(customerName);
            await NavigationService.GoBackAsync();
        }
    }
}
