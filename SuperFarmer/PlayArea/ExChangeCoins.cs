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

        /*
         * key(1)= what we want to exchange, 
         * inner key(2) = what it is exchanged to,
         * int1 = how much it costs from the first element,
         * int2 how much we get for the exchange 
         */
        private readonly Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>> changeValues =
            new Dictionary<HandEnum, Dictionary<HandEnum, (int, int)>>()
            {
                {HandEnum.Bunny, new Dictionary<HandEnum, (int, int)>(){ {HandEnum.Sheep, (6, 1) } } },

                {HandEnum.Sheep, new Dictionary<HandEnum, (int, int)>(){ {HandEnum.Bunny, (1, 6) },
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

        public bool ExchangeAnimalCoins(int cost, HandEnum exchangeFromAnimal, int worth, HandEnum exchangeTo, IHand hand, CoinDeck deck)
        {
            var temp = changeValues[exchangeFromAnimal];

            if (temp.ContainsKey(exchangeTo))
            {
                var (ExchangeBaseCost, ExchangeBaseWorth) = changeValues[exchangeFromAnimal][exchangeTo];
                if ((cost == ExchangeBaseCost || cost % ExchangeBaseCost == 0) &&
                    hand.GetElementInHand[exchangeFromAnimal] >= cost)
                {
                    if (deck.SubstractFromDeck(exchangeTo, worth) == true)
                    {
                        deck.AddToDeck(exchangeFromAnimal, cost);
                        hand.LoseAnimal(exchangeFromAnimal, cost);
                        hand.AddAnimal(exchangeTo, worth);
                    }

                }
            }

            return true;
        }

        public Dictionary<HandEnum, List<(int, HandEnum, int)>> GetPossibleExchanges(IHand hand, CoinDeck deck)
        {
            var temp = new Dictionary<HandEnum, List<(int, HandEnum, int)>>();

            foreach (var animalInPlayersHand in hand.GetElementInHand)
            {
                GetPossibleExchanges(animalInPlayersHand.Key, animalInPlayersHand.Value,  deck ,temp);

                //for (int i = 1; i < 10; i++)
                //{
                //    if (animalInPlayersHand.Value >= cost * i)
                //    {
                //        if (deck.CanBeSubstractedFromDeck(animalType, worth) == true)
                //        {
                //            if (!temp.ContainsKey(animalInPlayersHand.Key))
                //            {
                //                temp.Add(animalInPlayersHand.Key, new List<(int, HandEnum, int)>() { (cost, animalType, worth) });
                //            }
                //            else
                //            {
                //                temp[animalInPlayersHand.Key].Add((cost * i, animalType, worth * i));
                //            }
                //        }

                //    }


            }
            return temp;
        }

        public Dictionary<HandEnum, List<(int, HandEnum, int)>> GetPossibleExchanges(HandEnum animalInPlayersHand, int animalInPlayersHandValue, CoinDeck deck, Dictionary<HandEnum, List<(int, HandEnum, int)>> dict)
        {
            if (changeValues.ContainsKey(animalInPlayersHand))
            {
                foreach (var (animalType, (cost, worth)) in changeValues[animalInPlayersHand])
                {

                    if (animalInPlayersHandValue >= cost)
                    {
                        if (deck.CanBeSubstractedFromDeck(animalType, worth) == true)
                        {
                            if (!dict.ContainsKey(animalInPlayersHand))
                            {
                                dict.Add(animalInPlayersHand, new List<(int, HandEnum, int)>() { (cost, animalType, worth) });
                            }
                            else
                            {
                                dict[animalInPlayersHand].Add((cost, animalType, worth));
                            }
                        }
                    }
                }
            }
            return dict;
        }

    }
}
