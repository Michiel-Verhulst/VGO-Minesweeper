using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace ViewModel.Commands
{
    public class UncoverSquareCommand : ICommand
    {
        private readonly ICell<IGame> Game;
        private readonly Vector2D Position;

        public string GameStatusMessage { get; private set; }

        public UncoverSquareCommand(ICell<IGame> game, Vector2D position)
        {
            Game = game;
            Position = position;
        }

        public bool CanExecute(object parameter)
        {
            return Game.Value.Board[Position].Status == SquareStatus.Covered 
                && Game.Value.Status == GameStatus.InProgress;
        }

        public void Execute(object parameter)
        {
            Game.Value = Game.Value.UncoverSquare(Position);
            Debug.WriteLine($"Uncovering square at position {Position}");
        }

        public event EventHandler CanExecuteChanged;
    }
}
