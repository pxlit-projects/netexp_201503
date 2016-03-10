using BrewzDomain.Classes;
using BrewzWPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BrewzWPF.Utilities;
using GalaSoft.MvvmLight.Messaging;

namespace BrewzWPF.ViewModel
{
    public class BrewerOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IBrewerDataService brewerDataService;
        private IDialogService dialogService;
        public ICommand ViewDetailCommand { get; set; }

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

        public BrewerOverviewViewModel(IBrewerDataService brewerDataService, IDialogService dialogService)
        {
            this.brewerDataService = brewerDataService;
            this.dialogService = dialogService;
            LoadData();
            LoadCommands();
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
        private void LoadCommands()
        {
            ViewDetailCommand = new CustomCommand(ViewDetailBrewer, CanViewDetailBrewer);
        }

        private void ViewDetailBrewer(object obj)
        {
            Messenger.Default.Send<Brewer>(selectedBrewer);
            dialogService.ShowDetailDialog();
        }

        private bool CanViewDetailBrewer(object obj)
        {
            if (SelectedBrewer != null)
            {
                return true;
            }
            return false;
        }
    }
}
