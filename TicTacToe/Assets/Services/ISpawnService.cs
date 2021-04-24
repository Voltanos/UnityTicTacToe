using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Services
{
    public interface ISpawnService
    {
        public GameObject SpawnWithNoRotation(GameObject instance, Vector3 spawnPosition);
    }
}