using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Enumerations;

namespace TicTacToe.Services
{
    public interface IAreaService
    {
        public AreaModel UpdateSign(AreaModel model, SignType type);
    }
}
