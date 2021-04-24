using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Enumerations;

namespace TicTacToe.Services
{
    public interface IUIService
    {
        public UIModel Start(UIModel model);
        public UIModel NewGame(UIModel model);
        public void ExitGame();
        public UIModel ShowCanvas(UIModel model, SignType type);
    }
}