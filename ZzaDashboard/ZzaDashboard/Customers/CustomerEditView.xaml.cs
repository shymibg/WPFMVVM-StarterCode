using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zza.Data;
using ZzaDashboard.Services;
namespace ZzaDashboard.Customers
{
    /// <summary>
    /// Interaction logic for CustomerEditView.xaml
    /// </summary>
    public partial class CustomerEditView : UserControl
    {

        //private ICustomersRepository _customerRepo = new CustomersRepository();
        //private Customer _customer = null;

        public CustomerEditView()
        {
            InitializeComponent();
        }

        //public Guid CustomerId
        //{
        //    get { return (Guid)GetValue(CustomerIdProperty); }
        //    set { SetValue(CustomerIdProperty, value); }
        //}

        // Using a DependencyProperty as the backing store for CustomerId.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CustomerIdProperty =
        //    DependencyProperty.Register("CustomerId", typeof(Guid), typeof(CustomerEditView), new PropertyMetadata(Guid.Empty));

        //private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (DesignerProperties.GetIsInDesignMode(this)) return;

        //    _customer = await _customerRepo.GetCustomerAsync(CustomerId);
        //    DataContext = _customer;

        //    //if (_customer == null) return;
        //    //tbFirstName.Text = _customer.FirstName;
        //    //tbLastName.Text = _customer.LastName;
        //    //tbPhone.Text = _customer.Phone;
        //}

        //private async void button_Click(object sender, RoutedEventArgs e)
        //{
        //    //_customer.FirstName = tbFirstName.Text;
        //    //_customer.LastName = tbLastName.Text;
        //    //_customer.Phone = tbPhone.Text;

        //    await _customerRepo.UpdateCustomerAsync(_customer);
        //}
    }
}
