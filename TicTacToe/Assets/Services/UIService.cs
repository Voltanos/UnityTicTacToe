using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Enumerations;
using UnityEngine.UI;

namespace TicTacToe.Services
{
    public class UIService : IUIService
    {
        public UIModel Start(UIModel model)
        {
            model.Canvas.gameObject.SetActive(false);
            return model;
        }

        public UIModel NewGame(UIModel model)
        {
            model.Canvas.gameObject.SetActive(false);
            model.GameManager.CreateGrid();

            return model;
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public UIModel ShowCanvas(UIModel model, SignType type)
        {
            model.Canvas.gameObject.SetActive(true);

            switch (type)
            {
                case SignType.PLAYER_SIGN:
                    model.Title.text = "Player has won!";
                    break;

                case SignType.COMPUTER_SIGN:
                    model.Title.text = "Computer has won!";
                    break;

                case SignType.DEFAULT:
                    model.Title.text = "No more moves, it's a draw!";
                    break;
            }

            return model;
        }
    }
}