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
        private static BrewerOverviewViewModel brewerOverviewViewModel = new BrewerOverviewViewModel();
        private static BrewerDetailViewModel brewerDetailViewModel = new BrewerDetailViewModel();

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

    }
}
