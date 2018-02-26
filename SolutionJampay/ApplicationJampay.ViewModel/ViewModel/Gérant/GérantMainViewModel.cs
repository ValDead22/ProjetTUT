using System.ComponentModel;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{


    public class GérantMainViewModel : IViewModelBase
    {

        

        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;
        

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion        

       

        public GérantMainViewModel()
        {
            
        }

        
    }
}
