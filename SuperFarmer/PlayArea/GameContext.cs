using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.PlayArea
{
    public class GameContext
    {
        private AbstractGameState currentGameState;

        public void TransitionToState(AbstractGameState state)
        {
            currentGameState = state;
            currentGameState.EnterState(this);
        }

    }
}
