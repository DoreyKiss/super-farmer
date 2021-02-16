using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class Player
    {
        public Guid PlayerID { get; private set; }

        public IHand _curretHand { get; private set; }
        public Player(IHand hand)
        {
            PlayerID = new Guid();
            _curretHand = hand;
        }
    }
}
