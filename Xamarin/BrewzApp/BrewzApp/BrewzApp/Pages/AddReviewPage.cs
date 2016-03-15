using BrewzApp.Models;
using BrewzApp.ViewModels;
using System;
using Xamarin.Forms;

namespace BrewzApp.Pages
{
    public class AddReviewPage : ContentPage
    {
        private AddReviewViewModel addReviewViewModel = new AddReviewViewModel();
        private Brewer selectedBrewer;
        private Editor commentEditor;
        private Editor scoreEditor;

        public AddReviewPage(Brewer selectedBrewer)
        {
            this.selectedBrewer = selectedBrewer;
            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;
            Label lblName = new Label
            {
                Text = "Add review: ",
                TextColor = Color.Red,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            
            Label lblDescription = new Label
            {
                Text = "Description: " ,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontSize = 16
            };

            layout.Children.Add(lblName);
            layout.Children.Add(lblDescription);

            commentEditor = new Editor
            {
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontSize = 16
            };

            layout.Children.Add(commentEditor);

            Label lblScore = new Label
            {
                Text = "Score (1-10): ",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontSize = 16
            };

            layout.Children.Add(lblScore);

            scoreEditor = new Editor
            {
                Keyboard = Keyboard.Numeric,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontSize = 16
            };

            layout.Children.Add(scoreEditor);

            Button addButton = new Button
            {
                Text = "Add review",

            };
            addButton.Clicked += OnButtonClicked;
            layout.Children.Add(addButton);

        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            addReviewViewModel.saveReview(selectedBrewer,commentEditor.Text, scoreEditor.Text);
            this.Navigation.PushAsync(new BrewerDetailPage(selectedBrewer));
        }
    }
    
}
