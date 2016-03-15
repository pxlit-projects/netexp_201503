using BrewzApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BrewzApp
{
    public class App : Application
    {
        public App()
        {
            var np = new NavigationPage(new BrewerOverviewPage());
            MainPage = np;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
