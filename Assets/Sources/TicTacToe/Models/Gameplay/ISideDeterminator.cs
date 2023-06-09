﻿using TicTacToe.Shared;

namespace TicTacToe.Models.Gameplay
{
    public interface ISideDeterminator : IResettable
    {
        GameSide Determine();
    }
}