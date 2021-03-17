using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class RedDice : AbstractDice
    {
        public override List<AnimalEnum> DiceValues { get; } = new List<AnimalEnum>()
                {AnimalEnum.Cow, AnimalEnum.Pig, AnimalEnum.Sheep,
                AnimalEnum.Bunny, AnimalEnum.Bunny, AnimalEnum.Bunny,
                AnimalEnum.Wolf, AnimalEnum.Sheep, AnimalEnum.Sheep,
                AnimalEnum.Bunny, AnimalEnum.Bunny, AnimalEnum.Bunny };
    }

}
