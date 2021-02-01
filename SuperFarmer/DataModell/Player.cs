using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    internal class Player
    {
        public int PlayerID { get; private set; }

        public Hand _curretHand;
        public Player()
        {
        }
    }
}
