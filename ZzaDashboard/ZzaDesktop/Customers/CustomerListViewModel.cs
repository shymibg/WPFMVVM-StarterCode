using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        private ICustomersRepository _cutomerRepo = new CustomersRepository();
        private ObservableCollection<Customer> _customers;
        public RelayCommand<Customer> PlaceOrderCommand { get; }
        public RelayCommand<Customer> EditCustomerCommand { get; }
        public RelayCommand AddCustomerCommand { get; }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }

        public event Action<Guid> PlaceOrderReqested = delegate { };
        public event Action<Customer> AddCustomerReqested = delegate { };
        public event Action<Customer> EditCustomerReqested = delegate { };

        public CustomerListViewModel()
        {
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
        }

        private void OnEditCustomer(Customer customer)
        {
            EditCustomerReqested(customer);
        }

        private void OnAddCustomer()
        {
            AddCustomerReqested(new Customer() { Id = Guid.NewGuid() });
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderReqested(customer.Id);
        }

        public async void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(await _cutomerRepo.GetCustomersAsync());
        }
    }
}
