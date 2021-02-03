using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    internal class RedDice : AbstractDice
    {
        public override List<AnimalEnum> DiceValues
        {
            get { return _diceValues; }
        }
        private readonly List<AnimalEnum> _diceValues = new List<AnimalEnum>()
                {AnimalEnum.Cow, AnimalEnum.Pig, AnimalEnum.Sheep,
                AnimalEnum.Bunny, AnimalEnum.Bunny, AnimalEnum.Bunny,
                AnimalEnum.Wolf, AnimalEnum.Sheep, AnimalEnum.Sheep,
                AnimalEnum.Bunny, AnimalEnum.Bunny, AnimalEnum.Bunny };
    }

}
