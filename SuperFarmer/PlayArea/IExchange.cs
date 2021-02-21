using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public interface IExchange
    {
        public bool ExchangeAnimalCoins(int cost, HandEnum exchangFrom, int worth ,HandEnum exchangeTo, Player player, CoinDeck deck);

        public Dictionary<HandEnum, List<(int, HandEnum, int)>> GetPossibleExchanges(Player player, CoinDeck deck);
    }
}
