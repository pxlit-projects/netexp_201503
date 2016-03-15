using BrewzApp.Models;
using BrewzApp.Services;
using System.ComponentModel;

namespace BrewzApp.ViewModels
{
    public class BrewerDetailViewModel : INotifyPropertyChanged
    {
        private Brewer selectedBrewer;
        private BrewzDataService brewerDataService = new BrewzDataService();

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
        public BrewerDetailViewModel()
        {
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Init(int id)
        {
            SelectedBrewer = brewerDataService.GetBrewerById(id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
