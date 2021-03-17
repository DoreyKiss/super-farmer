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

        public IReadOnlyDictionary<HandEnum, int> GetElementInHand => ElementsInHand;

        private readonly Dictionary<HandEnum, int> ElementsInHand= new Dictionary<HandEnum, int>();

        public Hand()
        {
            using System.Linq;

            foreach (var handEnum in Enum.GetValues(typeof(HandEnum)).Cast<HandEnum>())
            {
                AddAnimal(handEnum);
            }
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
