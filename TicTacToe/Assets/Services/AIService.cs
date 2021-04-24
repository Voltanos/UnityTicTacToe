using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TicTacToe.Models;
using TicTacToe.Enumerations;
using TicTacToe.Scripts;

namespace TicTacToe.Services
{
    public class AIService : IAIService
    {
        #region Public Methods

        public GameManagerModel ComputerAction(GameManagerModel model)
        {
            if (!model.PlayerTurnCompleted || !model.IsRunning)
            {
                return model;
            }

            // 1 - If the player nearly has a row completed, block it.
            model = CheckForPlayerWin(model);

            // 2 - Select a random area to mark.
            model = MarkRandomArea(model);

            return model;
        }

        #endregion

        #region Helper Methods

        public GameManagerModel CheckForPlayerWin(GameManagerModel model)
        {
            foreach (WinningRowModel row in model.WinningRowList)
            {
                List<GameObject> list =
                    model.Areas.Where(x =>
                        x.GetComponent<AreaScript>().Model.Type == SignType.PLAYER_SIGN &&
                        (
                            x.transform.position == row.FirstPos ||
                            x.transform.position == row.SecondPos ||
                            x.transform.position == row.ThirdPos
                        )
                    )
                    .ToList();

                if (list.Count >= 2 && !model.ComputerTurnCompleted)
                {
                    model = BlockPlayerRow(model, row);
                }
            }

            return model;
        }

        public GameManagerModel BlockPlayerRow(GameManagerModel model, WinningRowModel row)
        {
            AreaScript area1 = model.Areas.Find(x => x.transform.position == row.FirstPos).GetComponent<AreaScript>();
            AreaScript area2 = model.Areas.Find(x => x.transform.position == row.SecondPos).GetComponent<AreaScript>();
            AreaScript area3 = model.Areas.Find(x => x.transform.position == row.ThirdPos).GetComponent<AreaScript>();

            model = CheckIfAreaIsAvailable(model, area1);
            model = CheckIfAreaIsAvailable(model, area2);
            model = CheckIfAreaIsAvailable(model, area3);

            return model;
        }

        public GameManagerModel MarkRandomArea(GameManagerModel model)
        {
            if (model.ComputerTurnCompleted)
            {
                return model;
            }

            int areaCount = 0;

            while (model.ComputerTurnCompleted == false && areaCount < model.Areas.Count)
            {
                int areaIndex = Random.Range(0, model.Areas.Count);
                AreaScript areaScript = model.Areas[areaIndex].GetComponent<AreaScript>();
                model = CheckIfAreaIsAvailable(model, areaScript);
                areaCount += 1;
            }

            return model;
        }

        public GameManagerModel CheckIfAreaIsAvailable(GameManagerModel model, AreaScript areaScript)
        {
            if (areaScript.Model.Type != SignType.DEFAULT)
            {
                return model;
            }

            areaScript.UpdateSign(SignType.COMPUTER_SIGN);
            model.ComputerTurnCompleted = true;
            return model;
        }

        #endregion
    }
}