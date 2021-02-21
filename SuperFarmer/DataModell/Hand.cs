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

        //todo make sure it this  is a deepcopy
        public Dictionary<HandEnum, int> GetElementInHand { get { return new Dictionary<HandEnum, int>(ElementsInHand); } }

        private readonly Dictionary<HandEnum, int> ElementsInHand= new Dictionary<HandEnum, int>();

        public Hand()
        {
            ElementsInHand.Add(HandEnum.Bunny, 0);
            UpdateProp(HandEnum.Bunny);
            ElementsInHand.Add(HandEnum.Sheep, 0);
            UpdateProp(HandEnum.Sheep);
            ElementsInHand.Add(HandEnum.Pig, 0);
            UpdateProp(HandEnum.Pig);
            ElementsInHand.Add(HandEnum.Cow, 0);
            UpdateProp(HandEnum.Cow);
            ElementsInHand.Add(HandEnum.Horse, 0);
            UpdateProp(HandEnum.Horse);
            ElementsInHand.Add(HandEnum.SmallDog, 0);
            UpdateProp(HandEnum.SmallDog);
            ElementsInHand.Add(HandEnum.BigDog, 0);
            UpdateProp(HandEnum.BigDog);
        }

        public void AddAnimal(HandEnum key, int value = 0)
        {
            ElementsInHand[key] = ElementsInHand[key] + value;
            UpdateProp(key);
        }

        public int GetAnimal(HandEnum key)
        {
            return ElementsInHand[key];
        }

        public void LoseAnimalAll(HandEnum key)
        {
            ElementsInHand[key] = 0;
            UpdateProp(key);
        }
        public void LoseAnimal(HandEnum key, int value)
        {
            ElementsInHand[key] = ElementsInHand[key] - value;
            UpdateProp(key);
        }

        private void UpdateProp(HandEnum key)
        {
            switch (key)
            {
                case HandEnum.Bunny:
                    Bunny = ElementsInHand[key];
                    return;
                case HandEnum.Sheep:
                    Sheep = ElementsInHand[key];
                    return;
                case HandEnum.Pig:
                    Pig = ElementsInHand[key];
                    return;
                case HandEnum.Cow:
                    Cow = ElementsInHand[key];
                    return;
                case HandEnum.Horse:
                    Horse = ElementsInHand[key];
                    return;
                case HandEnum.SmallDog:
                    SmallDog = ElementsInHand[key];
                    return;
                case HandEnum.BigDog:
                    BigDog = ElementsInHand[key];
                    return;
            }
        }
    }
}
