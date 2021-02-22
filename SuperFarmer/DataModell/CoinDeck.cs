using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class CoinDeck
    {
        //todo
        public Dictionary<HandEnum, int> Coins { get; private set; }

        public CoinDeck()
        {
            Coins = new Dictionary<HandEnum, int>
            {
                { HandEnum.Bunny, 60 },
                { HandEnum.Sheep, 24 },
                { HandEnum.Pig, 20 },
                { HandEnum.Cow, 12 },
                { HandEnum.Horse, 6 },
                { HandEnum.SmallDog, 4 },
                { HandEnum.BigDog, 2 }
            };
        }

        public bool CanBeSubstractedFromDeck(HandEnum key, int value)
        {
            if (Coins[key] - value >= 0)
            {
                return true;
            }
            return false;
        }

        public bool SubstractFromDeck(HandEnum key, int value)
        {

            if(CanBeSubstractedFromDeck(key, value))
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
