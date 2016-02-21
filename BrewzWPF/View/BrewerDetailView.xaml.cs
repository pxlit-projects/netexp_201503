using BrewzWPF.Services;
using System.Windows;

namespace BrewzWPF
{

    public partial class DetailWindow : Window
    {
        BrewerDataService brewersService = new BrewerDataService();
        int selectedId = 1;
        public DetailWindow()
        {
            InitializeComponent();
            this.Loaded += DetailWindow_Loaded;
        }

        void DetailWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = brewersService.GetBrewer(selectedId) ;
        }
    }
}
