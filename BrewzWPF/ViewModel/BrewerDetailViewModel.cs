using BrewzDomain.Classes;
using System.ComponentModel;

namespace BrewzWPF.ViewModel
{
    public class BrewerDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Brewer selectedBrewer;
        public Brewer SelectedBrewer
        {
            get
            {
                return selectedBrewer;
            }
            set
            {
                selectedBrewer = value;
                RaisePropertyChanged("SelectedBrewer");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
