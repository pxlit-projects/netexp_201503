using BrewzDomain.Classes;
using BrewzWPF.Utilities;
using System.ComponentModel;
using System.Windows.Input;
using BrewzWPF.Services;
using GalaSoft.MvvmLight.Messaging;

namespace BrewzWPF.ViewModel
{
    public class BrewerDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BrewerDataService brewerDataService;
        private DialogService dialogService = new DialogService();
        public ICommand AddReviewCommand { get; set; }

        private Brewer selectedBrewer;
        private Review newReview;

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
            brewerDataService = new BrewerDataService();
            AddReviewCommand = new CustomCommand(AddReviewView, CanAddReview);
            Messenger.Default.Register<Brewer>(this, OnBrewerReceived);
            Messenger.Default.Register<Review>(this, OnUpdateReviewListMessageReceived);
        }
                
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AddReviewView(object obj)
        {
            newReview = new Review();
            newReview.BrewerId = selectedBrewer.BrewerId;

            Messenger.Default.Send<Review>(newReview);
            dialogService.ShowAddReviewDialog();
        }
 
        private bool CanAddReview(object obj)
        {
            return true;
        }
        
        private void OnBrewerReceived(Brewer brewer)
        {
            SelectedBrewer = brewer;
        }

        private void OnUpdateReviewListMessageReceived(Review newReview)
        {
            dialogService.CloseAddReviewDialog();
            SelectedBrewer = brewerDataService.GetBrewer(selectedBrewer.BrewerId);
        }
    }
}
