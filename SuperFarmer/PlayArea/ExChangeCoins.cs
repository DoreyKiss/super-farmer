using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{

    public class ExChangeCoins : IExchange
    {

        //6bunny--> 1 sheep

        //1sheep-> 6 bunny
        //2sheep-->1 pig
        //1 sheep--> 1 small dog

        //1 pig--> 2 sheep
        //3pig--> 1cow
        //3 pig--> 1 big dog

        //1 cow --> 3 pig
        //2 cow--> 1 horse

        //1 horse--> 2 cow

        //1 small dog--> 1 sheep

        //1 bigdog--> 3 pig
        private readonly Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>> changeValues =
            new Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>>()
            {
                {HandEnum.Bunny, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Sheep, (6, 1) } } },

                {HandEnum.Sheep, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Bunny, (1, 6) },
                                                                         {HandEnum.Pig, (2, 1) },
                                                                         {HandEnum.SmallDog,(1, 1) } } },

                {HandEnum.Pig, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Sheep, (1, 2) },
                                                                       {HandEnum.Cow, (3, 1) },
                                                                       {HandEnum.BigDog,(3, 1) } } },

                {HandEnum.Cow, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Pig, (1, 3) },
                                                                         {HandEnum.Horse, (2, 1) } } },

                {HandEnum.Horse, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Cow, (1, 2) }} },

                {HandEnum.SmallDog, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Sheep, (1, 1) } } },

                {HandEnum.BigDog, new Dictionary<HandEnum, (int, int)>(){ { HandEnum.Pig, (1, 3) } } }
            };

        public bool ExchangeAnimalCoins(int cost, HandEnum exchangeFromAnimal, int worth ,HandEnum exchangeTo, Player player, CoinDeck deck)
        {
            var temp = changeValues[exchangeFromAnimal];

            if (temp.ContainsKey(exchangeTo))
            {
                var (ExchangeBaseCost, ExchangeBaseWorth) = changeValues[exchangeFromAnimal][exchangeTo];
                if((cost == ExchangeBaseCost || cost % ExchangeBaseCost == 0) &&
                    player._curretHand.GetElementInHand[exchangeFromAnimal] >= cost)
                {
                    if (deck.SubstractFromDeck(exchangeTo, worth) == true)
                    {
                        deck.AddToDeck(exchangeFromAnimal, cost);
                        player._curretHand.LoseAnimal(exchangeFromAnimal, cost);
                        player._curretHand.AddAnimal(exchangeTo, worth);
                    }

                }
            }

            return true;
        }

        public Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>> GetPossibleExchanges(Player player, CoinDeck deck)
        {
            var temp = new Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>>();

            foreach (var animalInPlayersHand in player._curretHand.GetElementInHand)
            {
                if (changeValues.ContainsKey(animalInPlayersHand.Key))
                {
                    foreach (var (animalType, (cost, worth)) in changeValues[animalInPlayersHand.Key])
                    {
                        //todo so we can exchange more, duplicate elements of dict most be resolved.. (cost*i, worth*i..) c
                        //for (int i = 1; i < 5; i++)
                        //{
                        //does the player has enough of the animal to make the exchange. //todo, is there enough coins left in the deck? if not, are there any other players to exchange with?
                        if (animalInPlayersHand.Value >= cost)
                        {
                            if (deck.SubstractFromDeck(animalType, worth) == true)
                            {
                                if (!temp.ContainsKey(animalInPlayersHand.Key))
                                {
                                    temp.Add(animalInPlayersHand.Key, new Dictionary<HandEnum, (int, int)>() { { animalType, (cost, worth) } });
                                    deck.AddToDeck(animalInPlayersHand.Key, cost);
                                }
                                else
                                {
                                    temp[animalInPlayersHand.Key].Add(animalType, (cost, worth));
                                    deck.AddToDeck(animalInPlayersHand.Key, cost);
                                }
                            }

                        
                        }
                    }
                }
            }
            return temp;
        }
    }
}
