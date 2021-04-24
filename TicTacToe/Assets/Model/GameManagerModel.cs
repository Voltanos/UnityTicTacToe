using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Enumerations;
using TicTacToe.Scripts;

namespace TicTacToe.Models
{
    [System.Serializable]
    public class GameManagerModel
    {
        #region Properties

        public List<GameObject> Areas;

        public List<Vector3> GridPos;

        public GameObject Area;

        public bool IsRunning;
        public bool PlayerTurnCompleted;
        public bool ComputerTurnCompleted;

        public SignType VictorSign;

        public UIScript UIScript;

        public List<WinningRowModel> WinningRowList;

        #endregion

        #region Constructors

        public GameManagerModel()
        {
            Areas = new List<GameObject>();
            GridPos = new List<Vector3>();

            Area = null;

            IsRunning = true;
            PlayerTurnCompleted = false;
            ComputerTurnCompleted = false;

            VictorSign = SignType.DEFAULT;

            UIScript = null;

            WinningRowList = new List<WinningRowModel>();
        }

        #endregion
    }
}

