using ConsoleSweep.Controlers;
using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using ConsoleSweep.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.ViewControlers
{
    public class ConsoleGameViewControler : IGameViewControler
    {
        IGameView view;

        public ConsoleGameViewControler()
        {
            view = new ConsoleGameView();
        }

        public ViewDrawStatus Draw(GameData gameData, PlayerData playerData)
        {
            return view.Draw(gameData, playerData);
        }

        public UpdateStatus ProcessGameKeyPress(ConsoleKey key)
        {
            UpdateStatus updateStatus = UpdateStatus.OK;

            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    updateStatus = GameControler.Instance.CurrentPlayerControler.Move(PlayerMoveType.Left, GameControler.Instance.CurrentPlayerData, GameControler.Instance.CurrentGameSettings);
                    break;

                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    updateStatus = GameControler.Instance.CurrentPlayerControler.Move(PlayerMoveType.Up, GameControler.Instance.CurrentPlayerData, GameControler.Instance.CurrentGameSettings);
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    updateStatus = GameControler.Instance.CurrentPlayerControler.Move(PlayerMoveType.Down, GameControler.Instance.CurrentPlayerData, GameControler.Instance.CurrentGameSettings);
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    updateStatus = GameControler.Instance.CurrentPlayerControler.Move(PlayerMoveType.Right, GameControler.Instance.CurrentPlayerData, GameControler.Instance.CurrentGameSettings);
                    break;

                case ConsoleKey.R:
                    updateStatus = UpdateStatus.Reset;
                    break;

                case ConsoleKey.F1:
                    updateStatus = UpdateStatus.ShowHelp;
                    break;

                case ConsoleKey.F2:
                    updateStatus = UpdateStatus.ShowSettings;
                    break;

                case ConsoleKey.Escape:
                    updateStatus = UpdateStatus.Terminate;
                    break;
            }

            if (updateStatus == UpdateStatus.OK)
            {
                updateStatus = GameControler.Instance.UpdateModels();
            }

            return updateStatus;
        }

        public void ShowError()
        {
            view.ShowError();
        }

        public void ShowHit()
        {
            view.ShowHit();
        }
    }
}
