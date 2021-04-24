using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Enumerations;

namespace TicTacToe.Models
{
    [System.Serializable]
    public class AreaModel
    {
        #region Properties

        public SignType Type;

        public SpriteRenderer SpriteRenderer;

        public Sprite PlayerSign;
        public Sprite ComputerSign;

        #endregion

        #region Constructors

        public AreaModel()
        {
            Type = SignType.DEFAULT;

            SpriteRenderer = null;

            PlayerSign = null;
            ComputerSign = null;
        }

        #endregion
    }
}