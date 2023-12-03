using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel.ScreenViewModels
{
    public class MainViewModel
    {
        public MainViewModel(IGame game)
        {
            // Create empty cell
            CurrentScreen = Cell.Create<ScreenViewModel>(null);

            // Create screen A
            var firstScreen = new SettingsScreenViewModel(game, this.CurrentScreen);

            // Put first screen in CurrentScreen cell
            CurrentScreen.Value = firstScreen;
        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }
}
