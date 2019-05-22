using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using ConsoleSweep.ViewControlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleSweep.Controlers
{
    public class GameControler
    {
        static GameControler _instance;

        public static GameControler Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameControler();
                    _instance.Init(new PlayerControler(), new ConsoleGameViewControler(), new GameSettings
                        {
                            Columns = Helpers.Constants.DefaultColumns,
                            Rows = Helpers.Constants.DefaultRows = 8,
                            Lives = Helpers.Constants.DefaultLives = 3,
                            Mines = Helpers.Constants.DefaultMines = 10
                        }
                    );
                }
                return _instance;
            }
        }

        public GameSettings CurrentGameSettings { get; set; }
        public GameData CurrentGameData { get; set; }
        public PlayerData CurrentPlayerData { get; set; }
        public IPlayerControler CurrentPlayerControler { get; set; }

        IGameViewControler GameViewControler { get; set; }
        public IGameViewControler CurrentGameViewControler { get; set; }

        public GameViews CurrentDisplayedView { get; set; }

        public void Init(IPlayerControler playerControler, IGameViewControler gameViewControler, GameSettings settings)
        {
            CurrentDisplayedView = GameViews.GameView;

            CurrentPlayerControler = playerControler;
            GameViewControler = gameViewControler;
            CurrentGameViewControler = GameViewControler;
            CurrentGameSettings = settings;

            CurrentGameData = BoardGenerationControler.Create(CurrentGameSettings);

            Reset();            
        }

        public void Reset()
        {
            CurrentGameData = BoardGenerationControler.Create(CurrentGameSettings);

            CurrentPlayerData = new PlayerData { CurrentPosition = new Position { Column = 0, Row = 0 }, Moves = 0, Lives = CurrentGameSettings.Lives } ;

            CurrentGameData.Status = GameStatus.Pending;
        }

        public int Run()
        {
            ConsoleKeyInfo keyInfo;
            UpdateStatus updateStatus = UpdateStatus.None;
            
            do
            {
                updateStatus = UpdateStatus.None;

                CurrentGameViewControler.Draw(CurrentGameData, CurrentPlayerData);

                while (!Console.KeyAvailable)
                {
                    Thread.Yield();
                }

                keyInfo = Console.ReadKey(true);

                updateStatus = CurrentGameViewControler.ProcessGameKeyPress(keyInfo.Key);
                
                switch(updateStatus)
                {
                    case UpdateStatus.Error:
                        CurrentGameViewControler.ShowError();
                        break;
                    case UpdateStatus.Hit:
                        CurrentGameViewControler.ShowHit();
                        break;
                    case UpdateStatus.ShowHelp:
                        CurrentDisplayedView = GameViews.HelpView;
                        CurrentGameViewControler = new HelpViewControler();
                        break;
                    case UpdateStatus.ShowSettings:
                        CurrentDisplayedView = GameViews.SettingsView;
                        CurrentGameViewControler = new SettingsViewControler();
                        break;
                    case UpdateStatus.Reset:                        
                        Reset();
                        CurrentDisplayedView = GameViews.GameView;
                        CurrentGameViewControler = GameViewControler;
                        CurrentGameViewControler.ShowHit();
                        break;
                    case UpdateStatus.Close:     
                        CurrentDisplayedView = GameViews.GameView;
                        CurrentGameViewControler = GameViewControler;
                        break;
                }


            } while (updateStatus != UpdateStatus.Terminate);
            return 0;
        }


        public UpdateStatus UpdateModels()
        {
            GameDisplayCell cell = CurrentGameData.CurrentScreenDisplayData.Columns[CurrentPlayerData.CurrentPosition.Column]?.Rows[CurrentPlayerData.CurrentPosition.Row]?.Cell;

            CurrentPlayerData.Moves++;
            if (cell.CellStatus != GameCellStatus.Opened)
            {
                cell.CellStatus = GameCellStatus.Opened;

                if (cell.CellType == GameCellType.Mine)
                {
                    CurrentPlayerData.Lives--;
                    UpdateStatus returnUpdate = CurrentPlayerData.Lives <= 0 ? UpdateStatus.Lost : UpdateStatus.Hit;

                    if(returnUpdate == UpdateStatus.Lost)
                    {
                        GameControler.Instance.CurrentGameData.Status = GameStatus.Lost;
                    }

                    return returnUpdate;
                }                
            }

            if (GameControler.Instance.CurrentPlayerData.CurrentPosition.Column ==
                                GameControler.Instance.CurrentGameData.CurrentScreenDisplayData.Columns.Count - 1
                            &&
                                GameControler.Instance.CurrentPlayerData.CurrentPosition.Row ==
                                    GameControler.Instance.CurrentGameData.CurrentScreenDisplayData.Columns[GameControler.Instance.CurrentPlayerData.CurrentPosition.Column].Rows.Count - 1)
            {
                GameControler.Instance.CurrentGameData.Status = GameStatus.Won;
            }
            else
            {
                GameControler.Instance.CurrentGameData.Status = GameStatus.Running;
            }

            return UpdateStatus.OK;
        }
    }
}
