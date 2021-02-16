using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class CoinDeck
    {
        //todo
        private Dictionary<IHand.HandEnum, int> Coins = new Dictionary<IHand.HandEnum, int>();

        public CoinDeck()
        {
            Coins.Add(IHand.HandEnum.Bunny, 60);
            Coins.Add(IHand.HandEnum.Sheep, 24);
            Coins.Add(IHand.HandEnum.Pig, 20);
            Coins.Add(IHand.HandEnum.Cow, 12);
            Coins.Add(IHand.HandEnum.Horse, 6);
            Coins.Add(IHand.HandEnum.SmallDog, 4);
            Coins.Add(IHand.HandEnum.BigDog, 2);
        }


        public bool SubstractFromDeck(IHand.HandEnum key, int value)
        {
            if (Coins[key] - value >= 0)
            {
                Coins[key] = Coins[key] - value;
                return true;
            }
            return false;
        }

        public void AddToDeck(IHand.HandEnum key, int value)
        {
            Coins[key] = Coins[key] + value;
        }
    }
}
