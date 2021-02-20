using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public interface IHand
    {
        public int Bunny { get;}

        public int Sheep { get;}

        public int Pig { get;}

        public int Cow { get; }

        public int Horse { get; }

        public int SmallDog { get; }

        public int BigDog { get; }

        public Dictionary<HandEnum, int> GetElementInHand { get; }

        public void AddAnimal(HandEnum key, int value);

        public int GetAnimal(HandEnum key);

        public void LoseAnimalAll(HandEnum key);
        public void LoseAnimal(HandEnum key, int value);
    }
}
