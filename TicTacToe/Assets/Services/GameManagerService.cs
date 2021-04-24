using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Enumerations;
using TicTacToe.Scripts;

namespace TicTacToe.Services
{
    public class GameManagerService : IGameManagerService
    {
        #region Properties

        private readonly ISpawnService _spawnService;

        #endregion

        #region Constructors

        public GameManagerService()
        {
            _spawnService = new SpawnService();
        }

        #endregion

        #region Public Methods

        public GameManagerModel CreateGrid(GameManagerModel model)
        {
            model = DestroyAreas(model);

            foreach (Vector3 pos in model.GridPos)
            {
                GameObject newArea = _spawnService.SpawnWithNoRotation(model.Area, pos);
                newArea.name = string.Format("Area ({0}, {1})", pos.y, pos.x);
                model.Areas.Add(newArea);
            }

            return model;
        }

        public GameManagerModel ClickEvent(GameManagerModel model)
        {
            if (Input.GetMouseButtonDown(0) && model.IsRunning && !model.PlayerTurnCompleted)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    model = CheckForAreaObject(model, hit.collider.gameObject);
                }
            }

            return model;
        }

        public GameManagerModel CheckVictoryCondition(GameManagerModel model)
        {
            if (!model.IsRunning)
            {
                return model;
            }

            model = CheckSignType(model, SignType.PLAYER_SIGN);
            model = CheckSignType(model, SignType.COMPUTER_SIGN);

            DeclareWinner(model);

            return model;
        }

        public GameManagerModel CheckDrawCondition(GameManagerModel model)
        {
            if (!model.IsRunning)
            {
                return model;
            }

            List<GameObject> list =
                model.Areas.Where(x =>
                    x.GetComponent<AreaScript>().Model.Type == SignType.DEFAULT
                ).ToList();

            if (list.Count == 0)
            {
                model = DeclareDraw(model);
            }

            return model;
        }

        public GameManagerModel NewRound(GameManagerModel model)
        {
            if (model.PlayerTurnCompleted && model.ComputerTurnCompleted && model.IsRunning)
            {
                model.PlayerTurnCompleted = false;
                model.ComputerTurnCompleted = false;
            }

            return model;
        }

        #endregion

        #region Helper Methods

        public GameManagerModel DestroyAreas(GameManagerModel model)
        {
            foreach (GameObject area in model.Areas)
            {
                GameObject.Destroy(area);
            }

            model.Areas.Clear();
            model.VictorSign = SignType.DEFAULT;
            model.IsRunning = true;
            model.PlayerTurnCompleted = false;
            model.ComputerTurnCompleted = false;
            return model;
        }

        public GameManagerModel DeclareDraw(GameManagerModel model)
        {
            model.UIScript.ShowCanvas(model.VictorSign);
            model.IsRunning = false;

            return model;
        }

        public void DeclareWinner(GameManagerModel model)
        {
            if (model.VictorSign == SignType.DEFAULT)
            {
                return;
            }

            model.UIScript.ShowCanvas(model.VictorSign);
        }

        public GameManagerModel CheckSignType(GameManagerModel model, SignType type)
        {
            foreach (WinningRowModel row in model.WinningRowList)
            {
                List<GameObject> list =
                model.Areas.Where(x =>
                    x.GetComponent<AreaScript>().Model.Type == type &&
                    (
                        x.transform.position == row.FirstPos ||
                        x.transform.position == row.SecondPos ||
                        x.transform.position == row.ThirdPos
                    )
                ).ToList();

                if (list.Count >= 3)
                {
                    return AssignSignTypeAsWinner(model, type);
                }
            }

            return model;
        }

        public GameManagerModel AssignSignTypeAsWinner(GameManagerModel model, SignType type)
        {
            model.VictorSign = type;
            model.IsRunning = false;

            return model;
        }

        public GameManagerModel CheckForAreaObject(GameManagerModel model, GameObject collision)
        {
            if (collision.layer != LayerMask.NameToLayer("Area"))
            {
                return model;
            }

            AreaScript script = collision.GetComponent<AreaScript>();
            return CheckAreaSignType(model, script);
        }

        public GameManagerModel CheckAreaSignType(GameManagerModel model, AreaScript script)
        {
            if (script.Model.Type != SignType.DEFAULT)
            {
                return model;
            }

            model.PlayerTurnCompleted = true;
            script.UpdateSign(SignType.PLAYER_SIGN);
            return model;
        }

        #endregion
    }

}