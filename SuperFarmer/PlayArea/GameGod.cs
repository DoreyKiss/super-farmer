using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public partial class GameGod
    {

        public List<Player> Players { get; set; } = new List<Player>();
        public Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>> CurrentPossibleChanges { get; private set; }
        public Random rnd = new Random();
        public CoinDeck deck;
        public StateEnum stateEnum { get; private set; }


        private int currentPLayer;
        private int playerNumberSum;
        private DiceThrowResultHandler resultHandler;
        private IExchange exchange;

        public GameGod()
        {
            resultHandler = new DiceThrowResultHandler();
            exchange = new ExChangeCoins();
        }

        public void StartGame(int numberOfPLayers)
        {
            Players.Clear();
            deck = new CoinDeck();
            for (int i = 0; i < numberOfPLayers; i++)
            {
                Players.Add(new Player(new Hand()));
            }
            playerNumberSum = numberOfPLayers;
            currentPLayer = 0;
            stateEnum = StateEnum.ThrowDice;
        }

        public void ChanegeCoins(int cost, HandEnum exhange, int worth, HandEnum exchangeTo)
        {
            exchange.ExchangeAnimalCoins(cost, exhange, worth, exchangeTo, Players[currentPLayer], deck);
            CurrentPossibleChanges = exchange.GetPossibleExchanges(Players[currentPLayer], deck);
            stateEnum = StateEnum.ThrowDice;
        }

        //if not change is require by user
        public void ChanegeCoins()
        {
            stateEnum = StateEnum.ThrowDice;
        }

        public (AnimalEnum, AnimalEnum) ThrowDice(IDice blueDice, IDice redDice)
        {

            var blue = blueDice.ThrowDice();
            var red = redDice.ThrowDice();
            resultHandler.GetResult(Players[currentPLayer], blue , red, deck);
            stateEnum = StateEnum.NextPlayer;

            //todo shall I leave it here or delete? (when game goes in a directed flow it is not necessery.)
            CurrentPossibleChanges = exchange.GetPossibleExchanges(Players[currentPLayer], deck);
            return (blue, red);
        }

        public int ChangePLayer()
        {
            var nextPLayer = currentPLayer = (currentPLayer + 1) % playerNumberSum; // CHANGE PLAYER 
            stateEnum = StateEnum.ChangeCoins;
            //by the time chanegeCoins is called, list shall be updated
            CurrentPossibleChanges = exchange.GetPossibleExchanges(Players[nextPLayer], deck);
            return nextPLayer;
        }

    }
}
