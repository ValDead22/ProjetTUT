using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class YesNoViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly RelayCommand _yesCommand;
        public ICommand YesCommand => _yesCommand;

        private readonly RelayCommand _noCommand;
        public ICommand NoCommand => _noCommand;

        public Action Close;

        

        public YesNoViewModel(string msg, Action yes)
        {
            _yesCommand = new RelayCommand(() => { yes(); Close(); }, o => true);
            _noCommand = new RelayCommand(() => Close(), o => true);
            Msg = msg;
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                OnPropertyChanged(nameof(Msg));
            }
        }

    }
}
