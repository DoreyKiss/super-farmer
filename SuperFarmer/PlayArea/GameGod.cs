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
        public StateEnum StateEnum { get; private set; }

        private CoinDeck _deck;
        private int _currentPLayer;
        private readonly DiceThrowResultHandler _resultHandler;
        private readonly IExchange _exchange;


        public GameGod(int numberOfPLayers)
        {
            _resultHandler = new DiceThrowResultHandler();
            _exchange = new ExChangeCoins();
            StartGame(numberOfPLayers);
        }

        public void StartGame(int numberOfPLayers)
        {
            Players.Clear();
            _deck = new CoinDeck();
            for (int i = 0; i < numberOfPLayers; i++)
            {
                Players.Add(new Player(new Hand()));
            }
            _currentPLayer = 0;
            StateEnum = StateEnum.ThrowDice;
        }

        public void ChanegeCoins(int cost, HandEnum exhange, int worth, HandEnum exchangeTo)
        {
            _exchange.ExchangeAnimalCoins(cost, exhange, worth, exchangeTo, Players[_currentPLayer]._curretHand, _deck);
            CurrentPossibleChanges = _exchange.GetPossibleExchanges(Players[_currentPLayer]._curretHand, _deck);
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
            _resultHandler.GetResult(Players[_currentPLayer]._curretHand, blue, red, _deck);
            StateEnum = StateEnum.NextPlayer;
            return (blue, red);
        }

        public int ChangePLayer()
        {
            var nextPlayer = _currentPLayer = (_currentPLayer + 1) % (Players.Count); // CHANGE PLAYER 
            StateEnum = StateEnum.ChangeCoins;
            //by the time chanegeCoins is called, list shall be updated
            CurrentPossibleChanges = _exchange.GetPossibleExchanges(Players[nextPlayer]._curretHand, _deck);
            if(CurrentPossibleChanges.Count == 0)
            {
                StateEnum = StateEnum.ThrowDice;
            }
            return nextPlayer;
        }

    }
}
