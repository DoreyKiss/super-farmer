using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class CoinDeck
    {
        //todo
        private Dictionary<HandEnum, int> Coins = new Dictionary<HandEnum, int>();

        public CoinDeck()
        {
            Coins.Add(HandEnum.Bunny, 60);
            Coins.Add(HandEnum.Sheep, 24);
            Coins.Add(HandEnum.Pig, 20);
            Coins.Add(HandEnum.Cow, 12);
            Coins.Add(HandEnum.Horse, 6);
            Coins.Add(HandEnum.SmallDog, 4);
            Coins.Add(HandEnum.BigDog, 2);
        }


        public bool SubstractFromDeck(HandEnum key, int value)
        {
            if (Coins[key] - value >= 0)
            {
                Coins[key] = Coins[key] - value;
                return true;
            }
            return false;
        }

        public void AddToDeck(HandEnum key, int value)
        {
            Coins[key] = Coins[key] + value;
        }
    }
}
