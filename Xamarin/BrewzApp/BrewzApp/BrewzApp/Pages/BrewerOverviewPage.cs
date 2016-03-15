using BrewzApp.Models;
using BrewzApp.ViewModels;
using Xamarin.Forms;

namespace BrewzApp.Pages
{
    public class BrewerOverviewPage : ContentPage
    {
        private BrewerOverviewViewModel brewerOvervieViewModel = new BrewerOverviewViewModel();
        private BrewerDetailViewModel brewerDetailViewModel = new BrewerDetailViewModel();
        ListView _brewersListView = new ListView {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

        public BrewerOverviewPage()
        {
            this.Content = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Init();
        }

        private void Init()
        {
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");

            _brewersListView.ItemTemplate = cell;

            brewerOvervieViewModel.LoadData();
            _brewersListView.ItemsSource = brewerOvervieViewModel.Brewers;

            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(
                    left: 0,
                    right: 0,
                    bottom: 0,
                    top: Device.OnPlatform(iOS: 20, Android: 0, WinPhone: 0)),
                Children =
                {
                    _brewersListView
                }
            };

            _brewersListView.ItemSelected += (sender, e) =>
            {
                var selectedBrewer = (Brewer) e.SelectedItem;
                brewerDetailViewModel.SelectedBrewer = selectedBrewer;
                this.Navigation.PushAsync(new BrewerDetailPage(selectedBrewer));
            };
        }
                
    }
}
