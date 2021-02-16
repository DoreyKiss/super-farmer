using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public interface IHand
    {
        public enum HandEnum{
            Bunny = AnimalEnum.Bunny,
            Sheep = AnimalEnum.Sheep,
            Pig = AnimalEnum.Pig,
            Cow = AnimalEnum.Cow,
            Horse = AnimalEnum.Horse,
            SmallDog = AnimalEnum.SmallDog,
            BigDog = AnimalEnum.BigDog,
        }

        public int Bunny { get;}

        public int Sheep { get;}

        public int Pig { get;}

        public int Cow { get; }

        public int Horse { get; }

        public int SmallDog { get; }

        public int BigDog { get; }

        public void AddAnimal(IHand.HandEnum key, int value);

        public int GetAnimal(IHand.HandEnum key);

        public void LoseAnimalAll(IHand.HandEnum key);
        public void LoseAnimal(IHand.HandEnum key, int value);

    }
}
