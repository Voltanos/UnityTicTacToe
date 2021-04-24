using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Enumerations;

namespace TicTacToe.Services
{
    public class AreaService : IAreaService
    {
        public AreaModel UpdateSign(AreaModel model, SignType type)
        {
            model.Type = type;

            switch (type)
            {
                case SignType.PLAYER_SIGN:
                    SwitchSprite(model, model.PlayerSign);
                    break;

                case SignType.COMPUTER_SIGN:
                    SwitchSprite(model, model.ComputerSign);
                    break;
            }

            return model;
        }

        public void SwitchSprite(AreaModel model, Sprite newSprite)
        {
            model.SpriteRenderer.sprite = newSprite;
        }
    }
}