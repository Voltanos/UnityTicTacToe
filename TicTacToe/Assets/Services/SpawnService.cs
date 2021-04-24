using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.Services
{
    public class SpawnService : ISpawnService
    {
        public GameObject SpawnWithNoRotation(GameObject instance, Vector3 spawnPosition)
        {
            return GameObject.Instantiate(instance, spawnPosition, Quaternion.identity);
        }
    }
}