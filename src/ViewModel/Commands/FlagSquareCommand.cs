using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class FlagSquareCommand : ICommand
    {
        private readonly ICell<IGame> Game;
        private readonly Vector2D Position;

        public FlagSquareCommand(ICell<IGame> game, Vector2D position)
        {
            Game = game;
            Position = position;

        }

        public bool CanExecute(object parameter)
        {
            return Game.Value.Status == GameStatus.InProgress 
                && (Game.Value.Board[Position].Status == SquareStatus.Covered 
                || Game.Value.Board[Position].Status == SquareStatus.Flagged);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                Game.Value = Game.Value.ToggleFlag(Position);
                Debug.WriteLine($"Flagging square at position {Position}");
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
