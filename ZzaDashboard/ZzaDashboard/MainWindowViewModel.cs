using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ZzaDashboard.Customers;

namespace ZzaDashboard
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Timer _timer;
        public object CurrentViewModel { get; set; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();

            _timer = new Timer(5000);
            _timer.Elapsed += (s, e) =>
             {
                 NotificationMessage = "Time is: " + DateTime.Now.ToString();
             };
            _timer.Start();
        }

        private string _notificationMessage;

        public string NotificationMessage
        {
            get { return _notificationMessage; }
            set
            {
                if (_notificationMessage == value) return;

                _notificationMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NotificationMessage"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
