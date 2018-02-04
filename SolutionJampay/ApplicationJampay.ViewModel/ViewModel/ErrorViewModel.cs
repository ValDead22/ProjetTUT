using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class ErrorViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        public ErrorViewModel(string message)
        {
            _message = message;
        }
    }
}
