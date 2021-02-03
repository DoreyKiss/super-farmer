using System;
using System.Collections.Generic;
using System.Text;
using SuperFarmer.DataModell;

namespace SuperFarmer.PlayArea
{
    public static class Dices
    {
        public static (AnimalEnum, AnimalEnum) RollDices()
        {
            RedDice rd = new RedDice();
            BlueDice bd = new BlueDice();
            return (rd.ThrowDice() , bd.ThrowDice()); ;
            //var (blue, red) = Dice.RolDice()
        }
    }
}
