using ConsoleSweep.Controlers;
using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using ConsoleSweep.ViewControlers;
using System;

namespace ConsoleSweep.Views
{
    public class SettingsView : IGameView
    {
        SettingsViewControler ViewControler { get; set; }  
        
        public SettingsView(SettingsViewControler view)
        {
            ViewControler = view;
        }
        public ViewDrawStatus Draw(GameData gameData, PlayerData playerData)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            int maxMines = Math.Min((gameData.CurrentScreenDisplayData.Columns.Count * gameData.CurrentScreenDisplayData.Columns[0].Rows.Count) / 2, 
                Helpers.Constants.MaxMines);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(2, 2);
            Console.Write("SETTINGS");
            Console.SetCursorPosition(2, 3);
            Console.Write("--------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 7);
            Console.Write("Lives({0}-{1}):", Helpers.Constants.MinLives, Helpers.Constants.MaxLives);
            Console.SetCursorPosition(2, 9);
            Console.Write("Columns({0}-{1}):", Helpers.Constants.MinColumns, Helpers.Constants.MaxColumns);
            Console.SetCursorPosition(2, 11);
            Console.Write("Rows({0}-{1}):", Helpers.Constants.MinRows, Helpers.Constants.MaxRows);
            Console.SetCursorPosition(2, 13);
            Console.Write("Mines({0}-{1}):", Helpers.Constants.MinMines, maxMines);

            Console.ForegroundColor = ViewControler.Lives <= Helpers.Constants.MinLives ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.SetCursorPosition(20, 7);
            Console.Write("< ");
            Console.ForegroundColor = ViewControler.Columns <= Helpers.Constants.MinColumns ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.SetCursorPosition(20, 9);
            Console.Write("< ");
            Console.ForegroundColor = ViewControler.Rows <= Helpers.Constants.MinRows ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.SetCursorPosition(20, 11);
            Console.Write("< ");
            Console.ForegroundColor = ViewControler.Mines <= Helpers.Constants.MinMines ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.SetCursorPosition(20, 13);
            Console.Write("< ");

            Console.ForegroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Lives ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.BackgroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Lives ? ConsoleColor.Blue : ConsoleColor.Black;
            Console.SetCursorPosition(21, 7);
            Console.Write(ViewControler.Lives);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ViewControler.Lives >= Helpers.Constants.MaxLives ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.Write(" >");

            Console.ForegroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Columns ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.BackgroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Columns ? ConsoleColor.Blue : ConsoleColor.Black;
            Console.SetCursorPosition(21, 9);
            Console.Write(ViewControler.Columns);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ViewControler.Columns >= Helpers.Constants.MaxColumns ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.Write(" >");

            Console.ForegroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Rows ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.BackgroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Rows ? ConsoleColor.Blue : ConsoleColor.Black;
            Console.SetCursorPosition(21, 11);
            Console.Write(ViewControler.Rows);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ViewControler.Rows >= Helpers.Constants.MaxRows ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.Write(" >");

            Console.ForegroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Mines ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.BackgroundColor = ViewControler.CurrentRow != SettingsViewControler.SettingRows.Mines ? ConsoleColor.Black : ConsoleColor.Blue;
            Console.SetCursorPosition(21, 13);
            Console.Write(ViewControler.Mines);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ViewControler.Mines >= Helpers.Constants.MaxMines ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.Write(" >");

            Console.ForegroundColor = ViewControler.DataChanged ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.BackgroundColor = ViewControler.CurrentRow == SettingsViewControler.SettingRows.Save ? ConsoleColor.Blue : ConsoleColor.Black;
            Console.SetCursorPosition(2, 17);
            Console.Write("Save (ENTER)");

            return ViewDrawStatus.Ok;
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void ShowHit()
        {
            throw new NotImplementedException();
        }
    }
}
