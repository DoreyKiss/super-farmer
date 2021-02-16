using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{

    public class Hand : IHand
    {
        public int Bunny { get; private set; }
        public int Sheep { get; private set; }
        public int Pig { get; private set; }
        public int Cow { get; private set; }
        public int Horse { get; private set; }
        public int SmallDog { get; private set; }
        public int BigDog { get; private set; }

        private Dictionary<IHand.HandEnum, int> ElementsInHand = new Dictionary<IHand.HandEnum, int>();

        public Hand()
        {

        }

        public void AddAnimal(IHand.HandEnum key, int value = 0)
        {
            if(!ElementsInHand.ContainsKey(key))
            {
                ElementsInHand.Add(IHand.HandEnum.Bunny, 0);
            }
            else
            {
                ElementsInHand[key] = ElementsInHand[key] + value;
            }

            UpdateProp(key);
        }

        public int GetAnimal(IHand.HandEnum key)
        {
            if (!ElementsInHand.ContainsKey(key))
            {
                ElementsInHand.Add(key, 0);
            }
            return ElementsInHand[key];
        }

        public void LoseAnimalAll(IHand.HandEnum key)
        {
            if (!ElementsInHand.ContainsKey(key))
            {
                ElementsInHand.Add(key, 0);
            }
            ElementsInHand[key] = 0;
            UpdateProp(key);
        }
        public void LoseAnimal(IHand.HandEnum key, int value)
        {
            if (!ElementsInHand.ContainsKey(key))
            {
                ElementsInHand.Add(key, 0);
            }
            ElementsInHand[key] = ElementsInHand[key] - value;
            UpdateProp(key);
        }

        private void UpdateProp(IHand.HandEnum key)
        {
            switch (key)
            {
                case IHand.HandEnum.Bunny:
                    Bunny = ElementsInHand[key];
                    return;
                case IHand.HandEnum.Sheep:
                    Sheep = ElementsInHand[key];
                    return;
                case IHand.HandEnum.Pig:
                    Pig = ElementsInHand[key];
                    return;
                case IHand.HandEnum.Cow:
                    Cow = ElementsInHand[key];
                    return;
                case IHand.HandEnum.Horse:
                    Horse = ElementsInHand[key];
                    return;
                case IHand.HandEnum.SmallDog:
                    SmallDog = ElementsInHand[key];
                    return;
                case IHand.HandEnum.BigDog:
                    BigDog = ElementsInHand[key];
                    return;
            }
        }
    }
}
