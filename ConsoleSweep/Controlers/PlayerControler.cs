using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;

namespace ConsoleSweep.Controlers
{
    public class PlayerControler : IPlayerControler
    {
        public UpdateStatus Move(PlayerMoveType move, PlayerData playerData, GameSettings settings)
        {
            if(GameControler.Instance.CurrentGameData.Status != GameStatus.Running &&
                GameControler.Instance.CurrentGameData.Status != GameStatus.Pending)
            {
                return UpdateStatus.None;
            }

            UpdateStatus returnStatus = UpdateStatus.OK;

            switch(move)
            {
                case PlayerMoveType.Up:
                    playerData.CurrentPosition.Row--;
                    break;
                case PlayerMoveType.Down:
                    playerData.CurrentPosition.Row++;
                    break;
                case PlayerMoveType.Left:
                    playerData.CurrentPosition.Column--;
                    break;
                case PlayerMoveType.Right:
                    playerData.CurrentPosition.Column++;
                    break;
            }

            if(playerData.CurrentPosition.Row < 0)
            {
                playerData.CurrentPosition.Row = 0;
                returnStatus = UpdateStatus.Error;
            }

            if (playerData.CurrentPosition.Column < 0)
            {
                playerData.CurrentPosition.Column = 0;
                returnStatus = UpdateStatus.Error;
            }

            if (playerData.CurrentPosition.Row >= settings.Rows)
            {
                playerData.CurrentPosition.Row = settings.Rows - 1;
                returnStatus = UpdateStatus.Error;
            }

            if (playerData.CurrentPosition.Column >= settings.Columns)
            {
                playerData.CurrentPosition.Column = settings.Columns - 1;
                returnStatus = UpdateStatus.Error;
            }

            if (returnStatus == UpdateStatus.OK)
            {
                GameControler.Instance.CurrentGameData.Score++;
            }

            return returnStatus;
        }
    }
}
