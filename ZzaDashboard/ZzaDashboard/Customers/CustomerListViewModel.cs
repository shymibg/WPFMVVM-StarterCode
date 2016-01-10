﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Customers
{
    public class CustomerListViewModel : INotifyPropertyChanged
    {
        private ICustomersRepository _customersRepo = new CustomersRepository();
        public RelayCommand DeleteCommand { get; private set; }

        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                if (_customers == value) return;

                _customers = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
            }
        }


        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;

            //Customers = new ObservableCollection<Customer>(_customersRepo.GetCustomersAsync().Result);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;

            Customers = new ObservableCollection<Customer>(await _customersRepo.GetCustomersAsync());
        }

        private Customer _selectedCustomer;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer == value) return;

                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }
    }
}
