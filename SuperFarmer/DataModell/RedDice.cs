using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    internal class RedDice : IDice
    {
        private readonly List<AnimalEnum> DiceValues = new List<AnimalEnum>()
                {AnimalEnum.cow, AnimalEnum.pig, AnimalEnum.sheep,
                AnimalEnum.bunny, AnimalEnum.bunny, AnimalEnum.bunny,
                AnimalEnum.wolf, AnimalEnum.sheep, AnimalEnum.sheep,
                AnimalEnum.bunny, AnimalEnum.bunny, AnimalEnum.bunny };

        public AnimalEnum ThrowDice()
        {
            Random rnd = new Random();
            return DiceValues[rnd.Next(0, 11)];
        }
    }

}
