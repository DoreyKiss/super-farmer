using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public class GameGod
    {

        public List<Player> Players { get; set; } = new List<Player>();
        public Random rnd = new Random();
        private int currentPLayer;
        private int playerNumberSum;
        private DiceThrowResultHandler resultHandler = new DiceThrowResultHandler();

        public void StartGame(int numberOfPLayers)
        {
            Players.Clear();
            for (int i = 0; i < numberOfPLayers; i++)
            {
                Players.Add(new Player(new Hand()));
            }
            playerNumberSum = numberOfPLayers;
            currentPLayer = 0;
        }

        public (AnimalEnum, AnimalEnum) ThrowDice(IDice blueDice, IDice redDice)
        {

            var blue = blueDice.ThrowDice();
            var red = redDice.ThrowDice();
            resultHandler.GetResult(Players[currentPLayer], blue , red);
            return (blue, red);

        }

        public int ChangePLayer()
        {
           return currentPLayer = (currentPLayer + 1) % playerNumberSum; // CHANGE PLAYER 
        }
    }
}
