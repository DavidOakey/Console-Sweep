using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSweep.Helpers;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;

namespace ConsoleSweep.Controlers
{
    public class BoardGenerationControler
    {
        public static GameData Create(GameSettings settings)
        {
            GameData data = CreateGameData(settings);

            PopulateMines(data, settings);

            return data;
        }

        private static void PopulateMines(GameData data, GameSettings settings)
        {
            int x, y = 0;
            int mines = 0;
            while(settings.Mines > mines)
            {
                x = Helper.RandomNumber(0, settings.Columns);
                y = Helper.RandomNumber(0, settings.Rows);

                if(
                    (x == 0 && y == 0) ||
                    (x == data.CurrentScreenDisplayData.Columns.Count - 1 &&
                    y == data.CurrentScreenDisplayData.Columns[x].Rows.Count - 1)
                  )
                {
                    continue;
                }

                if(data.CurrentScreenDisplayData.Columns[x].Rows[y].Cell.CellType != GameCellType.Mine)
                {
                    data.CurrentScreenDisplayData.Columns[x].Rows[y].Cell.CellType = GameCellType.Mine;
                    mines++;
                }
            }
        }

        private static GameData CreateGameData(GameSettings settings)
        {
            GameData data = 
            new GameData
            {
                Score = 0,
                Status = GameStatus.Pending,
                CurrentScreenDisplayData = new ScreenDisplayData
                {
                    Columns = new List<GameColumn>()
                }
            };


            for (int x = 0; x < settings.Columns; x++)
            {
                data.CurrentScreenDisplayData.Columns.Add(new GameColumn { Rows = new List<GameRow>() });
                for (int y = 0; y < settings.Rows; y++)
                {
                    data.CurrentScreenDisplayData.Columns[x].Rows.Add(new GameRow
                    {
                        Cell = new GameDisplayCell
                        {
                            CellStatus = GameCellStatus.Pending,
                            CellType = GameCellType.Clear
                        }
                    });
                }
            }

            data.CurrentScreenDisplayData.Columns[0].Rows[0].Cell.CellStatus = GameCellStatus.Opened;

            return data;
        }
    }
}
