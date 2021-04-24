using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Services;
using TicTacToe.Enumerations;

namespace TicTacToe.Scripts
{
    public class UIScript : MonoBehaviour
    {
        public UIModel Model = new UIModel();
        private readonly IUIService _service = new UIService();

        public void Start()
        {
            Model = _service.Start(Model);
        }

        public void NewGameEvent()
        {
            Model = _service.NewGame(Model);
        }

        public void ExitGameEvent()
        {
            _service.ExitGame();
        }

        public void ShowCanvas(SignType type)
        {
            Model = _service.ShowCanvas(Model, type);
        }
    }
}
