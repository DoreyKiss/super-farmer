using SuperFarmer.PlayArea;
using SuperFarmer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperFarmer.WPF.views
{
    /// <summary>
    /// Interaction logic for WellcomePageView.xaml
    /// </summary>
    public partial class WellcomePageView : Page
    {

        private WellComePageViewModell viewModell;

        public WellcomePageView()
        {
            viewModell = new WellComePageViewModell();
            InitializeComponent();
            DataContext = viewModell;
        }
        private void BtnClickStartGame(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new GamePageView(new GameGod(viewModell.NumberOfPlayers)));
        }
    }
}
