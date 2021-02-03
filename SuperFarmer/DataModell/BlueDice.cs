using System;
using System.Collections.Generic;

namespace SuperFarmer.DataModell
{
    public class BlueDice: AbstractDice
    {
        public override List<AnimalEnum> DiceValues
        {
            get {return _diceValues ;}
        }

        private readonly List<AnimalEnum> _diceValues = new List<AnimalEnum>()
                {AnimalEnum.Fox, AnimalEnum.Pig, AnimalEnum.Sheep,
                AnimalEnum.Bunny, AnimalEnum.Bunny, AnimalEnum.Bunny,
                AnimalEnum.Horse, AnimalEnum.Pig, AnimalEnum.Sheep,
                AnimalEnum.Bunny, AnimalEnum.Bunny, AnimalEnum.Bunny };

    }
}
