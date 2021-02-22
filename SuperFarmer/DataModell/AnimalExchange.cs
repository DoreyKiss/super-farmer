using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class AnimalExchange
    {
        public HandEnum From { get; }

        public HandEnum To { get; }

        public int Cost { get; }

        public int Gain { get; }

        public AnimalExchange(HandEnum from, HandEnum to, int cost, int gain)
        {
            From = from;
            To = to;
            Cost = cost;
            Gain = gain;
        }

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


        public AnimalExchange Inverse() => new AnimalExchange(To, From, Gain, Cost);

        public static IEnumerable<AnimalExchange> UniqueExchanges
        {
            get
            {
                yield return new AnimalExchange(HandEnum.Bunny, HandEnum.Sheep, 6, 1);

                yield return new AnimalExchange(HandEnum.Sheep, HandEnum.Pig, 2, 1);

                //...
            }
        }

        public static IEnumerable<AnimalExchange> AllExchanges
        {
            get
            {
                return UniqueExchanges.Union(UniqueExchanges.Select(exchange => exchange.Inverse()));
            }
        }
    }
}
