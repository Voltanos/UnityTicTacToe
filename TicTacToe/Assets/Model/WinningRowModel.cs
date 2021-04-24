using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Models
{
    [System.Serializable]
    public class WinningRowModel
    {
        #region Properties

        public Vector3 FirstPos;
        public Vector3 SecondPos;
        public Vector3 ThirdPos;

        #endregion

        #region Constructor

        public WinningRowModel()
        {
            FirstPos = new Vector3();
            SecondPos = new Vector3();
            ThirdPos = new Vector3();
        }

        #endregion
    }
}