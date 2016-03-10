using BrewzDomain.Classes;
using System.ComponentModel;
using System.Windows.Input;
using System;
using BrewzWPF.Utilities;
using BrewzWPF.Services;
using GalaSoft.MvvmLight.Messaging;

namespace BrewzWPF.ViewModel
{
    public class AddReviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IBrewerDataService brewerDataService;

        public ICommand SaveReviewCommand { get; set; }

        private Review newReview;

        public Review NewReview
        {
            get
            {
                return newReview;
            }

            set
            {
                newReview = value;
                RaisePropertyChanged("NewReview");
            }
        }

        public AddReviewViewModel(IBrewerDataService brewerDataService)
        {
            this.brewerDataService = brewerDataService;
            SaveReviewCommand = new CustomCommand(SaveReviewView, CanSaveReview);
            Messenger.Default.Register<Review>(this, OnReviewReceived);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void SaveReviewView(object obj)
        {
            newReview.ReviewDate = DateTime.Now;
            //TODO replace hardcoded user when users are implemented
            newReview.UserId = 1;
            brewerDataService.SaveReview(newReview);
            Messenger.Default.Send<Review>(newReview);
        }

        private bool CanSaveReview(object obj)
        {
            return true;
        }

        private void OnReviewReceived(Review newReview)
        {
            NewReview = newReview;
        }
    }
}
