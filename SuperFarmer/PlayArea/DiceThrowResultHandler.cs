using System;
using System.Collections.Generic;
using System.Text;
using SuperFarmer.DataModell;

namespace SuperFarmer.PlayArea
{
    public class DiceThrowResultHandler
    {
        //todo when losing beacuse of fox or wolf shall we give stuff after losing stuff or before?
        public IHand GetResult(IHand hand, AnimalEnum blue, AnimalEnum red, CoinDeck deck)
        {
            //wolf fox cow and horse can only occure once
            if (red == blue)
            {
                AddAnimal(hand, red, deck, 2);
                return hand;
            }

            //If you roll a fox on one of the dice, you lose all the rabbits.
            //Put their counters back into the common stock.
            //Small dog keeps you safe from the fox
            //todo common stock
            if (blue == AnimalEnum.Fox)
            {
                if (hand.SmallDog != 0)
                {
                    deck.AddToDeck(HandEnum.SmallDog, 1);
                    hand.LoseAnimal(HandEnum.SmallDog, 1);
                }
                else
                {
                    deck.AddToDeck(HandEnum.Bunny, hand.Bunny);
                    hand.LoseAnimalAll(HandEnum.Bunny);
                }

            }
            else
            {
                AddAnimal(hand, blue, deck);
            }
            //If you roll a wolf on other dice, you lose all the animals
            //except horse and small dog(if one of these or both are in
            //your possession). Proceed as above and return the animals to
            //the common stock. Large dog protects your stock from the effects of wolf.
            if (red == AnimalEnum.Wolf)
            {
                if (hand.BigDog != 0)
                {
                    deck.AddToDeck(HandEnum.BigDog, 1);
                    hand.LoseAnimal(HandEnum.BigDog, 1);
                }
                else
                {
                    WolfAttack(hand, deck);
                }
            }
            else
            {
                AddAnimal(hand, red, deck);
            }

            return hand;
        }

        private IHand AddAnimal(IHand hand, AnimalEnum diceValue, CoinDeck deck , int numberOfoccurrences = 1)
        {
            var temp = hand.GetAnimal((HandEnum)diceValue);
            var (animal, number) = ((HandEnum)diceValue, (temp + numberOfoccurrences) / 2);
            if (number != 0)
            {
                var hasEnoughCoins = deck.SubstractFromDeck(animal, number);
                if (hasEnoughCoins)
                {
                    hand.AddAnimal(animal, number);
                }
            }
            return hand;
        }

        private void WolfAttack(IHand hand, CoinDeck deck)
        {
            deck.AddToDeck(HandEnum.Bunny, hand.Bunny);
            hand.LoseAnimalAll(HandEnum.Bunny);

            deck.AddToDeck(HandEnum.Sheep, hand.Sheep);
            hand.LoseAnimalAll(HandEnum.Sheep);

            deck.AddToDeck(HandEnum.Pig, hand.Pig);
            hand.LoseAnimalAll(HandEnum.Pig); ;

            deck.AddToDeck(HandEnum.Cow, hand.Cow);
            hand.LoseAnimalAll(HandEnum.Cow);
        }
    }
}


