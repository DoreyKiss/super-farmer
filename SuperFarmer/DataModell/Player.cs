using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    internal class Player
    {
        public Guid PlayerID { get; private set; }

        public Hand _curretHand { get; private set; }
        public Player()
        {
            PlayerID = new Guid();
        }
    }
}
