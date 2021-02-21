using System;
using System.Collections.Generic;

namespace SuperFarmer.DataModell
{
    public abstract class AbstractDice : IDice
    {
        public  abstract List<AnimalEnum> DiceValues { get;}
        private readonly Random rnd = new Random();

        public AnimalEnum ThrowDice()
        {
            return DiceValues[rnd.Next(0, DiceValues.Count)];
        }
    }
}
