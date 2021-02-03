using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    
    public class Hand : IHand
    {
        public int Bunny { get; set ; }
        public int Sheep { get; set ; }
        public int Pig { get ; set ; }
        public int Cow { get ; set ; }
        public int Horse { get ; set ; }
        public int SmallDog { get; set ; }
        public int BigDog { get; set ; }
        private Dictionary<AnimalEnum, int> Coins { get; set; }
    }
}
