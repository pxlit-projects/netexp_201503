using BrewzApp.Models;
using BrewzApp.Services;
using System;

namespace BrewzApp.ViewModels
{
    public class AddReviewViewModel
    {
        private BrewzDataService brewerDataService = new BrewzDataService();

        public void saveReview(Brewer selectedBrewer, string comment, string score)
        {
            Review newReview = new Review();
            newReview.ReviewDate = DateTime.Now;
            newReview.BrewerId = selectedBrewer.BrewerId;
            newReview.ReviewComment = comment;
            newReview.ReviewScore = Int32.Parse(score);
            newReview.UserId = 1;
            brewerDataService.CreateReview(newReview);

        }
            
    }
}
