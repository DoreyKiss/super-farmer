using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public interface IExchange
    {
        public bool ExchangeAnimalCoins(int cost, HandEnum exchangFrom, int worth ,HandEnum exchangeTo, IHand hand, CoinDeck deck);

        public Dictionary<HandEnum, List<(int, HandEnum, int)>> GetPossibleExchanges(IHand hand, CoinDeck deck);
        public Dictionary<HandEnum, List<(int, HandEnum, int)>> GetPossibleExchanges(HandEnum animalInPlayerHand, int animalInPlayerHandValue, CoinDeck deck, Dictionary<HandEnum, List<(int, HandEnum, int)>>? temp);
    }
}
