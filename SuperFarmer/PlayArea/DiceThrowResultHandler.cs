using System;
using System.Collections.Generic;
using System.Text;
using SuperFarmer.DataModell;

namespace SuperFarmer.PlayArea
{
    public class DiceThrowResultHandler
    {
        //todo when losing beacuse of fox or wolf shall we give stuff after losing stuff or before?
        public void GetResult(Player player, AnimalEnum blue, AnimalEnum red, CoinDeck deck)
        {
            //wolf fox cow and horse can only occure once
            if (red == blue)
            {
                AddAnimal(player, red, deck, 2);
                return;
            }

            //If you roll a fox on one of the dice, you lose all the rabbits.
            //Put their counters back into the common stock.
            //Small dog keeps you safe from the fox
            //todo common stock
            if (blue == AnimalEnum.Fox)
            {
                if (player._curretHand.SmallDog != 0)
                {
                    deck.AddToDeck(HandEnum.SmallDog, 1);
                    player._curretHand.LoseAnimal(HandEnum.SmallDog, 1);
                }
                else
                {
                    deck.AddToDeck(HandEnum.Bunny, player._curretHand.Bunny);
                    player._curretHand.LoseAnimalAll(HandEnum.Bunny);
                }

            }
            else
            {
                AddAnimal(player, blue, deck);
            }
            //If you roll a wolf on other dice, you lose all the animals
            //except horse and small dog(if one of these or both are in
            //your possession). Proceed as above and return the animals to
            //the common stock. Large dog protects your stock from the effects of wolf.
            if (red == AnimalEnum.Wolf)
            {
                if (player._curretHand.BigDog != 0)
                {
                    //todo lose only one dog
                    deck.AddToDeck(HandEnum.BigDog, 1);
                    player._curretHand.LoseAnimal(HandEnum.BigDog, 1);
                }
                else
                {
                    WolfAttack(player, deck);
                }
            }
            else
            {
                AddAnimal(player, red, deck);
            }
        }

        private void AddAnimal(Player player, AnimalEnum diceValue, CoinDeck deck , int numberOfoccurrences = 1)
        {
            var temp = player._curretHand.GetAnimal((HandEnum)diceValue);
            var (animal, number) = ((HandEnum)diceValue, (temp + numberOfoccurrences) / 2);
            if (number != 0)
            {
                var hasEnoughCoins = deck.SubstractFromDeck(animal, number);
                if (hasEnoughCoins)
                {
                    player._curretHand.AddAnimal(animal, number);
                }
            }
        }

        private void WolfAttack(Player player, CoinDeck deck)
        {
            deck.AddToDeck(HandEnum.Bunny, player._curretHand.Bunny);
            player._curretHand.LoseAnimalAll(HandEnum.Bunny);

            deck.AddToDeck(HandEnum.Sheep, player._curretHand.Sheep);
            player._curretHand.LoseAnimalAll(HandEnum.Sheep);

            deck.AddToDeck(HandEnum.Pig, player._curretHand.Pig);
            player._curretHand.LoseAnimalAll(HandEnum.Pig);

            deck.AddToDeck(HandEnum.Cow, player._curretHand.Cow);
            player._curretHand.LoseAnimalAll(HandEnum.Cow);
        }
    }
}

