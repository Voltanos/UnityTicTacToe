using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TicTacToe.Scripts;

namespace TicTacToe.Models
{
    [System.Serializable]
    public class UIModel
    {
        public Canvas Canvas;
        public Text Title;
        public GameManager GameManager;

        public UIModel()
        {
            Canvas = null;
            Title = null;
            GameManager = null;
        }
    }
}