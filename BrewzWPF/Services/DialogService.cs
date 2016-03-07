using BrewzWPF.View;
using System;
using System.Windows;

namespace BrewzWPF.Services
{
    public class DialogService : IDialogService
    {
        Window brewerDetailView = null;
        Window addReviewView = null;

        public void CloseAddReviewDialog()
        {
            if (addReviewView != null)
                addReviewView.Close();
        }

        public void CloseDetailDialog()
        {
            if (brewerDetailView != null)
                brewerDetailView.Close();
        }

        public void ShowAddReviewDialog()
        {
            addReviewView = new AddReviewView();
            addReviewView.ShowDialog();
        }

        public void ShowDetailDialog()
        {
            brewerDetailView = new BrewerDetailWindow();
            brewerDetailView.ShowDialog();
        }
    }
}
