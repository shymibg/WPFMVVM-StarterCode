using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;
namespace ZzaDesktop
{
    public class MainWindowViewModel : BindableBase
    {
        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel = new AddEditCustomerViewModel();
        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavigateCommand = new RelayCommand<string>(OnNavigate);
            _customerListViewModel.PlaceOrderReqested += NavToPlaceOrder;
            _customerListViewModel.AddCustomerReqested += NavToAddCustomer;
            _customerListViewModel.EditCustomerReqested += NavToEditCustomer;
            _addEditCustomerViewModel.Done += NavToCustomerList;
        }

        private void NavToCustomerList()
        {
            CurretnViewModel = _customerListViewModel;
        }

        private void NavToEditCustomer(Zza.Data.Customer obj)
        {
            _addEditCustomerViewModel.EditMode = true;
            _addEditCustomerViewModel.EditingCustomer = obj;
            CurretnViewModel = _addEditCustomerViewModel;
        }

        private void NavToAddCustomer(Zza.Data.Customer obj)
        {
            _addEditCustomerViewModel.EditMode = false;
            _addEditCustomerViewModel.EditingCustomer = obj;
            CurretnViewModel = _addEditCustomerViewModel;
        }

        private void NavToPlaceOrder(Guid customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurretnViewModel = _orderViewModel;
        }

        public BindableBase CurretnViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public RelayCommand<string> NavigateCommand { get; }

        private void OnNavigate(string destination)
        {
            switch (destination)
            {
                case "orderPrep":
                    CurretnViewModel = _orderPrepViewModel;
                    break;
                case "customers":
                default:
                    CurretnViewModel = _customerListViewModel;
                    break;
            }
        }
    }
}
