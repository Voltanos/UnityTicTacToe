using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Services;
using TicTacToe.Enumerations;

namespace TicTacToe.Scripts
{
    public class AreaScript : MonoBehaviour
    {
        public AreaModel Model = new AreaModel();
        private readonly IAreaService _service = new AreaService();

        public void UpdateSign(SignType type)
        {
            Model = _service.UpdateSign(Model, type);
        }
    }
}
