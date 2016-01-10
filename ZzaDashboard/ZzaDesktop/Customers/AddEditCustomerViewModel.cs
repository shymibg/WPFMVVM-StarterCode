using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Customers
{
    public class AddEditCustomerViewModel : BindableBase
    {
        private bool _editMode;

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        private Customer _editingCustomer;

        public Customer EditingCustomer
        {
            private get { return _editingCustomer; }
            set
            {
                _editingCustomer = value;
                Customer = new SimpleEditableCustomer();
                CopyCustomer(_editingCustomer, Customer);
            }
        }

        private SimpleEditableCustomer _simpleEditableCustomer;

        public SimpleEditableCustomer Customer
        {
            get { return _simpleEditableCustomer; }
            set { SetProperty(ref _simpleEditableCustomer, value); }
        }

        public void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            if(EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Phone = source.Phone;
                target.Email = source.Email;
            }
        }

        public RelayCommand SaveCommand { get;}
        public RelayCommand CancelCommand { get;}
        public event Action Done = delegate { };

        public AddEditCustomerViewModel()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnCancel()
        {
            Done();
        }

        private bool CanSave()
        {
            return true;
        }

        private void OnSave()
        {
            Done();
        }
    }
}
