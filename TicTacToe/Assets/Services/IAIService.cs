using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public interface IAIService
    {
        public GameManagerModel ComputerAction(GameManagerModel model);
    }
}