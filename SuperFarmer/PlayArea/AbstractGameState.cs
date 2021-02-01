using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public abstract class AbstractGameState
    {
        public abstract void EnterState(GameContext game);

    }
}
