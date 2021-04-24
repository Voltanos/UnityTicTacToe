using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public interface IGameManagerService
    {
        public GameManagerModel CreateGrid(GameManagerModel model);
        public GameManagerModel ClickEvent(GameManagerModel model);
        public GameManagerModel CheckVictoryCondition(GameManagerModel model);
        public GameManagerModel CheckDrawCondition(GameManagerModel model);
        public GameManagerModel NewRound(GameManagerModel model);
    }
}