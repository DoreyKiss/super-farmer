using SuperFarmer.DataModell;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class GamePageView : Page
    {
        private GameGod gameGod;
        private MainViewModel gameViewModel;
        private BlueDice blueDice;
        private RedDice redDice;


        public GamePageView(GameGod _gameGod, MainViewModel viewModel)
        {
            gameGod = _gameGod;
            gameViewModel = viewModel;
            InitializeComponent();
            DataContext = gameViewModel;
            blueDice = new BlueDice();
            redDice = new RedDice();
        }
        public GamePageView( GameGod _gameGod, MainViewModel viewModel, IDice _redDice, IDice _blueDice)
        {
            gameGod = _gameGod;
            gameViewModel = viewModel;
            InitializeComponent();
            DataContext = gameViewModel;
            blueDice = (BlueDice)_blueDice;
            redDice = (RedDice)_redDice;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var (blue, red) = gameGod.ThrowDice(blueDice, redDice);
            gameViewModel.BlueDice = blue;
            gameViewModel.RedDice = red;
            
        }
    }
}
