using BrewzDomain.Classes;
using BrewzWPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BrewzWPF.ViewModel
{
    public class BrewerOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BrewerDataService brewerDataService;
        private ObservableCollection<Brewer> brewers;
        public ObservableCollection<Brewer> Brewers
        {
            get
            {
                return brewers;
            }
            set
            {
                brewers = value;
                RaisePropertyChanged("Brewers");
            }
        }

        public BrewerOverviewViewModel()
        {
            brewerDataService = new BrewerDataService();
            LoadData();
        }

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

        private void LoadData()
        {
            List<Brewer> brewersList = brewerDataService.GetAllBrewers();
            Brewers = new ObservableCollection<Brewer>(brewersList);
        }
    }
}
