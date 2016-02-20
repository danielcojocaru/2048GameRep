﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine2048
{
    public interface IGameEngine
    {
        /// <summary>
        /// Gets the starting matrix for the given size
        /// </summary>
        /// <param name="size">size of the matrix you want to play</param>
        /// <returns></returns>
        void StartGame();

        /// <summary>
        /// Applies move
        /// </summary>
        /// <param name="moveType"></param>
        /// <returns></returns>
        void ApplyMove(EMoveType moveType);

        /// <summary>
        /// Return the previous move
        /// </summary>
        /// <returns></returns>
        void Undo();
    }
}
