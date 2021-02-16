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

        private void Throw_Dice_Click(object sender, RoutedEventArgs e)
        {
            var (blue, red) = gameGod.ThrowDice(blueDice, redDice);
            gameViewModel.BlueDice = blue;
            gameViewModel.RedDice = red;
            UpdatePLayerValues();
        }

        private void Change_PLayer_Click(object sender, RoutedEventArgs e)
        {
            gameViewModel.CurrentPLayerIndex = gameGod.ChangePLayer();
            UpdatePLayerValues();
        }

        private void UpdatePLayerValues()
        {
            gameViewModel.NumberOfCurrentPlayersBunnies = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.Bunny;
            gameViewModel.NumberOfCurrentPlayersSheeps = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.Sheep;
            gameViewModel.NumberOfCurrentPlayersPigs = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.Pig;
            gameViewModel.NumberOfCurrentPlayersCows = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.Cow;
            gameViewModel.NumberOfCurrentPlayersHorses = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.Horse;
            gameViewModel.NumberOfCurrentPlayersSmallDogs = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.SmallDog;
            gameViewModel.NumberOfCurrentPlayersBigDogs = gameGod.Players[gameViewModel.CurrentPLayerIndex]._curretHand.BigDog;
        }
    }
}
