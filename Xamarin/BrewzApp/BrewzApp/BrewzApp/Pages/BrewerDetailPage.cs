using BrewzApp.Models;
using BrewzApp.ViewModels;
using System;
using Xamarin.Forms;

namespace BrewzApp.Pages
{
    public class BrewerDetailPage : ContentPage
    {
        private BrewerDetailViewModel brewerDetailViewModel = new BrewerDetailViewModel();

        private Brewer selectedBrewer;
        ListView _brewerReviewsListView = new ListView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        public BrewerDetailPage(Brewer selectedBrewer)
        {
            brewerDetailViewModel.Init(selectedBrewer.BrewerId);
            this.selectedBrewer = brewerDetailViewModel.SelectedBrewer;

            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;
            Label lblName = new Label
            {
                Text = "Name brewer: " + selectedBrewer.Name,
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblJoinGroups = new Label
            {
                Text = "Individuals join groups: " + selectedBrewer.IndividualsJoinGroupsEn,
                TextColor = Color.White,
                FontAttributes = FontAttributes.None,
                FontSize = 16
            };
            Label lblDescription = new Label
            {
                Text = "Description: " + selectedBrewer.DescriptionEn,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontSize = 16
            };
            layout.Children.Add(lblName);
            layout.Children.Add(lblJoinGroups);
            layout.Children.Add(lblDescription);

            Button addReview = new Button
            {
                Text = "Add review",

            };
            addReview.Clicked += OnButtonClicked;
            layout.Children.Add(addReview);

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "ReviewComment");
            cell.SetBinding(TextCell.DetailProperty, "ReviewScore");
            _brewerReviewsListView.ItemTemplate = cell;
            _brewerReviewsListView.ItemsSource = selectedBrewer.Reviews;
            layout.Children.Add(_brewerReviewsListView);
            
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddReviewPage(brewerDetailViewModel.SelectedBrewer));
        }
    }

}
