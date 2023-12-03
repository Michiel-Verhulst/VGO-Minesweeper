using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel;
using ViewModel.Commands;

namespace ViewModel.ScreenViewModels
{
    public class SettingsScreenViewModel : ScreenViewModel
    {
        public int BoardSize { get; set; }
        public double BombProbability { get; set; }
        public bool FloodingEnabled { get; set; }
        public string Error { get; set; }
        public int MaxBoardSize { get; set; } = IGame.MaximumBoardSize;
        public int MinBoardSize { get; set; } = IGame.MinimumBoardSize;
        public double MaxProbChange { get; set; } = IGame.MaxProbChange * 10;
        public double MinProbChange { get; set; } = IGame.MinProbChange * 10;


        public IGame Game;
        public ICommand StartGameCommand { get; }
        public ICommand EasyGameCommand { get; }
        public ICommand MediumGameCommand { get; }
        public ICommand HardGameCommand { get; }

        public SettingsScreenViewModel(IGame game, ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            this.Game = game;
            FloodingEnabled = true;
            BoardSize = game.Board.Height;
            BombProbability = 1;


            //Start Game Preset command
            StartGameCommand = new ActionCommand(() => StartGame(game));

            //Easy Game Preset command
            EasyGameCommand = new ActionCommand(() => StartEasyGame());

            //Medium Game Preset command
            MediumGameCommand = new ActionCommand(() => StartMediumGame());

            //Hard Game Preset command
            HardGameCommand = new ActionCommand(() => StartHardGame());

        }

        private void StartGame(IGame game)
        {
            try
            {
                game = IGame.CreateRandom(BoardSize, BombProbability/10, FloodingEnabled);
                CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
            }
            catch (Exception e)
            {
                Error = e.Message;
            }
        }

        // Default value for the Easy preset
        private void StartEasyGame()
        {
            var game = IGame.CreateRandom(5, 0.2, true);
            CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
        }

        // Default value for the Medium preset
        private void StartMediumGame()
        {
            var game = IGame.CreateRandom(13, 0.3, true);
            CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
        }

        // Default value for the Hard preset
        private void StartHardGame()
        {
            var game = IGame.CreateRandom(20, 0.4, true);
            CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
        }
    }
}
