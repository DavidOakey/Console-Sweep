using ConsoleSweep.Controlers;
using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace ConsoleSweep.Views
{
    public class ConsoleGameView : IGameView
    {
        GameData LastGameData { get; set; }
        PlayerData LastPlayerData { get; set; }

        int xOffset = 10;
        int yOffset = 10;

        public ViewDrawStatus Draw(GameData gameData, PlayerData playerData)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            AddPlayInfoAndScores(gameData, playerData);

            if (DrawGameGrid(gameData, playerData) != ViewDrawStatus.Ok)
            {
                return ViewDrawStatus.Error;
            }

            if(gameData.Status == GameStatus.Lost)
            {
                AddLostText(gameData, playerData);
            }
            if (gameData.Status == GameStatus.Won)
            {
                AddLWonText(gameData, playerData);
            }

            return ViewDrawStatus.Ok;
        }

        private void AddLWonText(GameData gameData, PlayerData playerData)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(xOffset, yOffset +gameData.CurrentScreenDisplayData.Columns[0].Rows.Count + 2);
            Console.Write(Helpers.Strings.WinningText);
        }

        private void AddPlayInfoAndScores(GameData gameData, PlayerData playerData)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(2, 1);
            Console.Write(Helpers.Strings.HeaderText);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(2, 3);
            Console.Write(Helpers.Strings.ScoreLineTextFormater, playerData.Moves, playerData.Lives);

            Console.ForegroundColor = gameData.CurrentScreenDisplayData.Columns[playerData.CurrentPosition.Column].Rows[playerData.CurrentPosition.Row].Cell.CellType == GameCellType.Mine
                            ? ConsoleColor.Red : ConsoleColor.Green;
            Console.SetCursorPosition(2, 5);
            Console.Write("Position: {0} {1}", (char)(playerData.CurrentPosition.Column + 65), playerData.CurrentPosition.Row + 1);
        }

        private void AddLostText(GameData gameData, PlayerData playerData)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset + gameData.CurrentScreenDisplayData.Columns[0].Rows.Count + 2);
            Console.Write(Helpers.Strings.LoosingText);
        }

        public ViewDrawStatus DrawGameGrid(GameData gameData, PlayerData playerData)
        { 
            Console.CursorVisible = false;

            LastGameData = gameData;
            LastPlayerData = playerData;

            Console.SetCursorPosition(xOffset - 2, yOffset);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Helpers.Constants.StartEndChar);

            Console.SetCursorPosition(xOffset + gameData.CurrentScreenDisplayData.Columns.Count, 
                yOffset + gameData.CurrentScreenDisplayData.Columns.Last().Rows.Count - 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Helpers.Constants.StartEndChar);

            for (int x = 0; x < gameData.CurrentScreenDisplayData.Columns.Count; x++)
            {
                for (int y = 0; y < gameData.CurrentScreenDisplayData.Columns[x].Rows.Count; y++)
                {
                    Console.SetCursorPosition(x + xOffset, y + yOffset);

                    if (playerData.CurrentPosition.Column  == x &&
                        playerData.CurrentPosition.Row  == y)
                    {
                        Console.BackgroundColor = gameData.CurrentScreenDisplayData.Columns[x].Rows[y].Cell.CellType == GameCellType.Mine 
                            ? ConsoleColor.Red : ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(Helpers.Constants.PlayChar);
                    }
                    else
                    {
                        if (gameData.CurrentScreenDisplayData.Columns[x].Rows[y].Cell.CellStatus == GameCellStatus.Pending)
                        {                            
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Helpers.Constants.PendingChar);
                        }
                        else if (gameData.CurrentScreenDisplayData.Columns[x].Rows[y].Cell.CellStatus == GameCellStatus.Opened)
                        {
                            if (gameData.CurrentScreenDisplayData.Columns[x].Rows[y].Cell.CellType == GameCellType.Mine)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(Helpers.Constants.MineChar);
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(Helpers.Constants.OpendChar);
                            }
                        }
                    }
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;

            return ViewDrawStatus.Ok;
        }

        public void ShowError()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Thread.Sleep(Helpers.Constants.FlashTime);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public void ShowHit()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Thread.Sleep(Helpers.Constants.FlashTime);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
