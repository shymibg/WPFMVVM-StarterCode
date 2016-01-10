using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class CustomerEditViewModel : INotifyPropertyChanged
    {
        private ICustomersRepository _customerRepo = new CustomersRepository();
        private Customer _customer = null;

        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        public CustomerEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (value != Customer)
                {
                    _customer = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customer"));
                }
            }
        }

        public Guid CustomerId { get; set; }
        public ICommand SaveCommand { get; set; }

        public async void LoadCustomer()
        {
            Customer = await _customerRepo.GetCustomerAsync(CustomerId);
        }

        private async void OnSave()
        {
            Customer = await _customerRepo.UpdateCustomerAsync(Customer);
        }
    }
}
