using BrewzDomainDataAccessLayer;
using BrewzWPF.Services;
using BrewzWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzWPF
{
    public class ViewModelLocator
    {
        private static IDialogService dialogService = new DialogService();
        private static IBrewerDataService brewerDataService = new BrewerDataService(new BrewerRepository());

        private static BrewerOverviewViewModel brewerOverviewViewModel = new BrewerOverviewViewModel(brewerDataService, dialogService);
        private static BrewerDetailViewModel brewerDetailViewModel = new BrewerDetailViewModel(brewerDataService, dialogService);
        private static AddReviewViewModel addReviewViewModel = new AddReviewViewModel(brewerDataService);

        public static BrewerOverviewViewModel BrewerOverviewViewModel
        {
            get
            {
                return brewerOverviewViewModel;
            }
        }

        public static BrewerDetailViewModel BrewerDetailViewModel
        {
            get
            {
                return brewerDetailViewModel;
            }
        }

        public static AddReviewViewModel AddReviewViewModel
        {
            get
            {
                return addReviewViewModel;
            }
        }

    }
}
