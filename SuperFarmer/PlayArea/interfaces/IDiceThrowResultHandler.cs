using SuperFarmer.DataModell;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public interface IDiceThrowResultHandler
    {
        public void GetResult(IHand hand, AnimalEnum blue, AnimalEnum red, CoinDeck deck);
    }
}
