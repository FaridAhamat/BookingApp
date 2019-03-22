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
	public class CustomerManagementViewModel : ViewModelBase
    {
        private readonly CustomerService customerService;
        private ObservableCollection<Customer> customers;
        private DelegateCommand navigateCreateCustomer;

        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public DelegateCommand NavigateCreateCustomer =>
            navigateCreateCustomer ?? (navigateCreateCustomer = new DelegateCommand(ExecuteNavigateCreateCustomer));

        public CustomerManagementViewModel(INavigationService navigationService, CustomerService customerService) : base(navigationService)
        {
            this.customerService = customerService;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var customers = await customerService.GetAllCustomersAsync();

                Customers = new ObservableCollection<Customer>(customers);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading data in: {ex}");
            }
        }

        private void ExecuteNavigateCreateCustomer()
        {
            // TODO
        }
    }
}
