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
    public class SettingsViewControler : IGameViewControler
    {
        public enum SettingRows
        {
            Lives,
            Columns,
            Rows,
            Mines,
            Save
        }

        IGameView view;

        public int Lives { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int Mines { get; set; }

        public SettingRows CurrentRow { get; set; } = SettingRows.Lives;

        public SettingsViewControler()
        {
            view = new SettingsView(this);


            Lives = GameControler.Instance.CurrentGameSettings.Lives;
            Columns = GameControler.Instance.CurrentGameSettings.Columns;
            Rows = GameControler.Instance.CurrentGameSettings.Rows;
            Mines = GameControler.Instance.CurrentGameSettings.Mines;
        }

        public bool DataChanged
        {
            get
            {
                return Lives != GameControler.Instance.CurrentGameSettings.Lives ||
                Columns != GameControler.Instance.CurrentGameSettings.Columns ||
                Rows != GameControler.Instance.CurrentGameSettings.Rows ||
                Mines != GameControler.Instance.CurrentGameSettings.Mines;
            }
        }

        public ViewDrawStatus Draw(GameData gameData, PlayerData playerData)
        {
            return view.Draw(gameData, playerData);
        }

        public UpdateStatus ProcessGameKeyPress(ConsoleKey key)
        {
            UpdateStatus updateStatus = UpdateStatus.None;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    OnleftClick();
                    break;
                case ConsoleKey.UpArrow:
                    OnUpClick();
                    break;
                case ConsoleKey.DownArrow:
                    OnDownClick();
                    break;
                case ConsoleKey.RightArrow:
                    OnRightClick();
                    break;
                case ConsoleKey.Enter:                    
                    updateStatus = OnSaveClick(); 
                    break;
            }
            return updateStatus;
        }

        private void OnDownClick()
        {
            switch (CurrentRow)
            {
                case SettingRows.Lives:
                    CurrentRow = SettingRows.Columns;
                    break;
                case SettingRows.Columns:
                    CurrentRow = SettingRows.Rows;
                    break;
                case SettingRows.Rows:
                    CurrentRow = SettingRows.Mines;
                    break;
                case SettingRows.Mines:
                    CurrentRow = SettingRows.Save;
                    break;
                case SettingRows.Save:
                    break;
            }
        }

        private void OnUpClick()
        {
            switch (CurrentRow)
            {
                case SettingRows.Lives:
                    break;
                case SettingRows.Columns:
                    CurrentRow = SettingRows.Lives;
                    break;
                case SettingRows.Rows:
                    CurrentRow = SettingRows.Columns;
                    break;
                case SettingRows.Mines:
                    CurrentRow = SettingRows.Rows;
                    break;
                case SettingRows.Save:
                    CurrentRow = SettingRows.Mines;
                    break;
            }
        }

        private void OnleftClick()
        {
            switch (CurrentRow)
            {
                case SettingRows.Lives:
                    Lives -= Lives > Helpers.Constants.MinLives ? 1 : 0;
                    break;
                case SettingRows.Columns:
                    Columns -= Columns > Helpers.Constants.MinColumns ? 1 : 0;
                    break;
                case SettingRows.Rows:
                    Rows -= Rows > Helpers.Constants.MinRows ? 1 : 0;
                    break;
                case SettingRows.Mines:
                    Mines -= Mines > Helpers.Constants.MinMines ? 1 : 0;
                    break;
                case SettingRows.Save:
                    break;
            }
        }

        private void OnRightClick()
        {
            switch(CurrentRow)
            {
                case SettingRows.Lives:
                    Lives += Lives < Helpers.Constants.MaxLives ? 1 : 0;
                    break;
                case SettingRows.Columns:
                    Columns += Columns < Helpers.Constants.MaxColumns ? 1 : 0;
                    break;
                case SettingRows.Rows:
                    Rows += Rows < Helpers.Constants.MaxRows ? 1 : 0;
                    break;
                case SettingRows.Mines:
                    Mines += Mines < Helpers.Constants.MaxMines ? 1 : 0;
                    break;
                case SettingRows.Save:
                    break;
            }
        }

        UpdateStatus OnSaveClick()
        {
            if(CurrentRow == SettingRows.Save && DataChanged)
            {
                GameControler.Instance.CurrentGameSettings.Lives = Lives;
                GameControler.Instance.CurrentGameSettings.Columns = Columns;
                GameControler.Instance.CurrentGameSettings.Rows = Rows;
                GameControler.Instance.CurrentGameSettings.Mines = Mines;

                return UpdateStatus.Reset;
            }

            return UpdateStatus.None;
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
