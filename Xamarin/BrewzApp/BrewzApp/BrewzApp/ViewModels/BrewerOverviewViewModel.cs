using BrewzApp.Models;
using BrewzApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzApp.ViewModels
{
    public class BrewerOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Brewer> brewers;
        private BrewzDataService brewerDataService = new BrewzDataService();

        public ObservableCollection<Brewer> Brewers
        {
            get
            {
                return brewers;
            }
            set
            {
                brewers = value;
            }
        }

        public BrewerOverviewViewModel()
        {
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

        public void LoadData()
        {
            List<Brewer> brewersList = brewerDataService.GetBrewers();
            Brewers = new ObservableCollection<Brewer>(brewersList.OrderBy(b => b.Name));
        }

    }
}
