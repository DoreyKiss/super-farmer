using SuperFarmer.DataModell;
using SuperFarmer.PlayArea;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly BlueDice blueDice;
        private readonly RedDice redDice;
        private readonly Dictionary<string, (int, HandEnum, int, HandEnum)> mapStringsToChanges= new Dictionary<string, (int, HandEnum, int, HandEnum)>();


        public GamePageView(GameGod _gameGod, MainViewModel viewModel)
        {
            gameGod = _gameGod;
            gameViewModel = viewModel;
            InitializeComponent();
            DataContext = gameViewModel;
            blueDice = new BlueDice();
            redDice = new RedDice();
            UpdatePLayerValues();
        }

        public GamePageView(GameGod _gameGod, MainViewModel viewModel, IDice _redDice, IDice _blueDice)
        {
            gameGod = _gameGod;
            gameViewModel = viewModel;
            InitializeComponent();
            DataContext = gameViewModel;
            blueDice = (BlueDice)_blueDice;
            redDice = (RedDice)_redDice;
            UpdatePLayerValues();
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
            gameViewModel.CurrentPlayerIndex = gameGod.ChangePLayer();
            UpdatePLayerValues();
        }

        private void UpdatePLayerValues()
        {
            gameViewModel.NumberOfCurrentPlayersBunnies = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.Bunny;
            gameViewModel.NumberOfCurrentPlayersSheeps = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.Sheep;
            gameViewModel.NumberOfCurrentPlayersPigs = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.Pig;
            gameViewModel.NumberOfCurrentPlayersCows = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.Cow;
            gameViewModel.NumberOfCurrentPlayersHorses = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.Horse;
            gameViewModel.NumberOfCurrentPlayersSmallDogs = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.SmallDog;
            gameViewModel.NumberOfCurrentPlayersBigDogs = gameGod.Players[gameViewModel.CurrentPlayerIndex]._curretHand.BigDog;
            if(gameGod.CurrentPossibleChanges != null)
            {
                gameViewModel.PossibleChanges = GetListOfChanges(gameGod.CurrentPossibleChanges);
            }
            gameViewModel.GameStateEnum = gameGod.stateEnum;
        }

        private void ExchangeCoinsClick(object sender, RoutedEventArgs e)
        {
            //todo, shall replace with a more ux friendly solution 
            if (gameViewModel.SelectedChange is null)
            {
                gameGod.ChanegeCoins();

            }
            else
            {
                var (cost, changeFromAnimal, worth, changeToAnimal) = mapStringsToChanges[gameViewModel.SelectedChange];
                gameGod.ChanegeCoins(cost, changeFromAnimal, worth, changeToAnimal);
            }


            UpdatePLayerValues();
        }


        //todo shall we be able to exchange 12 bunnyies in the same time? etc
        private ObservableCollection<string> GetListOfChanges(Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>> dict)
        {
            mapStringsToChanges.Clear();
            
            var tempList = new ObservableCollection<string>();
            foreach (var a in dict)
            {
                foreach (var (animalType, (cost, worth)) in a.Value)
                {
                    var tempString = cost.ToString() + a.Key.ToString() + " --> " + worth.ToString() + " " + animalType;
                    tempList.Add(tempString);
                    mapStringsToChanges.Add(tempString, (cost, a.Key, worth, animalType));
                }
            }
            return tempList;
        }

    }
}

