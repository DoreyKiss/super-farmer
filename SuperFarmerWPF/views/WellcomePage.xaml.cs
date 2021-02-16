using SuperFarmer.PlayArea;
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
        private GameGod gameGod;
        private MainViewModel gameViewModel;

        public WellcomePageView(GameGod _gameGod, MainViewModel viewModel)
        {
            gameGod = _gameGod;
            gameViewModel = viewModel;
            InitializeComponent();
            DataContext = gameViewModel;
        }
        private void BtnClickStartGame(object sender, RoutedEventArgs e)
        {
            
            gameGod.StartGame(gameViewModel.NumberOfPlayers);
            NavigationService.Navigate(new GamePageView(gameGod, gameViewModel));
        }
    }
}
