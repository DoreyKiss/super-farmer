using System;
using System.Collections.Generic;
using System.Text;
using SuperFarmer.DataModell;

namespace SuperFarmer.PlayArea
{
    public class DiceThrowResultHandler
    {

        //todo when losing beacuse of fox or wolf shall we give stuff after losing stuff or before?
        public void GetResult(Player player, AnimalEnum blue, AnimalEnum red)
        {
            //wolf fox cow and horse can only occure once
            if (red == blue)
            {
                var temp = player._curretHand.GetAnimal((IHand.HandEnum)red);
                player._curretHand.AddAnimal((IHand.HandEnum)red, (temp + 2) / 2);
                return;
            }

            //If you roll a fox on one of the dice, you lose all the rabbits.
            //Put their counters back into the common stock.
            //Small dog keeps you safe from the fox
            //todo common stock
            if (red == AnimalEnum.Fox)
            {
                if (player._curretHand.SmallDog != 0)
                {
                    player._curretHand.LoseAnimalAll(IHand.HandEnum.SmallDog);
                }
                else
                {
                    WolfAttack(player);
                }

            }
            //If you roll a wolf on other dice, you lose all the animals
            //except horse and small dog(if one of these or both are in
            //your possession). Proceed as above and return the animals to
            //the common stock. Large dog protects your stock from the effects of wolf.
            if (blue == AnimalEnum.Wolf)
            {
                if (player._curretHand.BigDog != 0)
                {
                    //todo lose only one dog
                    player._curretHand.LoseAnimal(IHand.HandEnum.SmallDog, 1);
                }
                else
                {
                    player._curretHand.LoseAnimalAll(IHand.HandEnum.Bunny);
                }
            }

            var tempRed = player._curretHand.GetAnimal((IHand.HandEnum)red);
            player._curretHand.AddAnimal((IHand.HandEnum)red, (tempRed + 2) / 2);

            var tempBlue = player._curretHand.GetAnimal((IHand.HandEnum)blue);
            player._curretHand.AddAnimal((IHand.HandEnum)blue, (tempBlue + 2) / 2);
            return;
        }



        private void WolfAttack(Player player)
        {
            player._curretHand.LoseAnimalAll(IHand.HandEnum.Bunny);
            player._curretHand.LoseAnimalAll(IHand.HandEnum.Sheep);
            player._curretHand.LoseAnimalAll(IHand.HandEnum.Pig);
            player._curretHand.LoseAnimalAll(IHand.HandEnum.Cow);
        }
    }
}

