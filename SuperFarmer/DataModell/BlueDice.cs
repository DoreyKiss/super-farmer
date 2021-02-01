using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class BlueDice: IDice
    {
        private readonly List<AnimalEnum> DiceValues = new List<AnimalEnum>()
                {AnimalEnum.fox, AnimalEnum.pig, AnimalEnum.sheep,
                AnimalEnum.bunny, AnimalEnum.bunny, AnimalEnum.bunny,
                AnimalEnum.horse, AnimalEnum.pig, AnimalEnum.sheep,
                AnimalEnum.bunny, AnimalEnum.bunny, AnimalEnum.bunny };

        public AnimalEnum ThrowDice()
        {
            Random rnd = new Random();
            return DiceValues[rnd.Next(0, 11)];
        }
    }
}
