using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public partial class GameGod
    {

        public List<Player> Players { get; private set; } = new List<Player>();
        public Dictionary<HandEnum, List<(int, HandEnum, int)>> CurrentPossibleChanges { get; private set; }
        public Random rnd = new Random();
        public CoinDeck deck;
        public StateEnum StateEnum { get; private set; }


        private int currentPLayer;
        private DiceThrowResultHandler resultHandler;
        private IExchange exchange;

        public GameGod(int numberOfPLayers)
        {
            resultHandler = new DiceThrowResultHandler();
            exchange = new ExChangeCoins();
            StartGame(numberOfPLayers);
        }

        public void StartGame(int numberOfPLayers)
        {
            Players.Clear();
            deck = new CoinDeck();
            for (int i = 0; i < numberOfPLayers; i++)
            {
                Players.Add(new Player(new Hand()));
            }
            currentPLayer = 0;
            StateEnum = StateEnum.ThrowDice;
        }

        public void ChanegeCoins(int cost, HandEnum exhange, int worth, HandEnum exchangeTo)
        {
            exchange.ExchangeAnimalCoins(cost, exhange, worth, exchangeTo, Players[currentPLayer], deck);
            CurrentPossibleChanges = exchange.GetPossibleExchanges(Players[currentPLayer], deck);
            StateEnum = StateEnum.ThrowDice;
        }

        //if no change is required by user
        public void ChanegeCoins()
        {
            StateEnum = StateEnum.ThrowDice;
        }

        public (AnimalEnum, AnimalEnum) ThrowDice(IDice blueDice, IDice redDice)
        {

            var blue = blueDice.ThrowDice();
            var red = redDice.ThrowDice();
            resultHandler.GetResult(Players[currentPLayer], blue , red, deck);
            StateEnum = StateEnum.NextPlayer;
            return (blue, red);
        }

        public int ChangePLayer()
        {
            var nextPlayer = currentPLayer = (currentPLayer + 1) % (Players.Count); // CHANGE PLAYER 
            StateEnum = StateEnum.ChangeCoins;
            //by the time chanegeCoins is called, list shall be updated
            CurrentPossibleChanges = exchange.GetPossibleExchanges(Players[nextPlayer], deck);
            if(CurrentPossibleChanges.Count == 0)
            {
                StateEnum = StateEnum.ThrowDice;
            }
            return nextPlayer;
        }

    }
}
