using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrewzWPF.Services;
using BrewzTest.Mocks;
using BrewzDomain.Classes;
using System.Collections.ObjectModel;
using BrewzWPF.ViewModel;

namespace BrewzTest
{
    [TestClass]
    public class BrewerOverviewViewModelTest
    {
        private IBrewerDataService brewerDataService;
        private IDialogService dialogService;

        [TestInitialize]
        public void Init()
        {
            brewerDataService = new MockBrewerDataService(new MockRepository());
            dialogService = new MockDialogService();
        }

        [TestMethod]
        public void LoadAllBrewers()
        {
            ObservableCollection<Brewer> brewers = null;
            var expectedBrewers = brewerDataService.GetAllBrewers();

            var viewModel = new BrewerOverviewViewModel(this.brewerDataService, this.dialogService);
            brewers = viewModel.Brewers;

            CollectionAssert.AreEqual(expectedBrewers, brewers);
        }
    }
}
