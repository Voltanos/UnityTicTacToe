using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Services;
using TicTacToe.Models;

namespace TicTacToe.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameManagerModel GameManagerModel = new GameManagerModel();
        private readonly IGameManagerService _gameManagerService = new GameManagerService();
        private readonly IAIService _aiService = new AIService();

        void Start()
        {
            CreateGrid();
        }

        public void CreateGrid()
        {
            GameManagerModel = _gameManagerService.CreateGrid(GameManagerModel);
        }

        void Update()
        {
            // 1 - Player turn.
            GameManagerModel = _gameManagerService.ClickEvent(GameManagerModel);
            GameManagerModel = _gameManagerService.CheckVictoryCondition(GameManagerModel);
            GameManagerModel = _gameManagerService.CheckDrawCondition(GameManagerModel);

            // 2 - Computer turn.
            GameManagerModel = _aiService.ComputerAction(GameManagerModel);
            GameManagerModel = _gameManagerService.CheckVictoryCondition(GameManagerModel);
            GameManagerModel = _gameManagerService.CheckDrawCondition(GameManagerModel);

            // 3 - New Round.
            GameManagerModel = _gameManagerService.NewRound(GameManagerModel);
        }
    }
}