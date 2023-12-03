using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class SquareViewModel
    {
        public ICell<Square> Square { get; }
        private readonly ICell<IGameBoard> gameBoard;
        private readonly Vector2D position;

        public Vector2D Position => position;

        public ICommand Uncover { get; }

        public ICommand Flag { get; }

        public ICell<bool> GameLostContainingMines { get; }

        public SquareViewModel(ICell<IGame> game, Vector2D position)
        {
            // Derive a cell for the game board from the game cell
            gameBoard = game.Derive(g => g.Board);

            // Derive a cell for the specific square based on its position in the game board
            Square = gameBoard.Derive(board => board[position]);

            // Assign the position field with the provided position
            this.position = position;

            // Create an UncoverSquareCommand for uncovering the square
            Uncover = new UncoverSquareCommand(game, position);

            // Create a FlagSquareCommand for flagging the square
            Flag = new FlagSquareCommand(game, position);

            // Derive a cell to check if the game is lost and the current square contains a mine
            GameLostContainingMines = game.Derive(g => g.Status == GameStatus.Lost && g.Mines.Contains(position));
        }


    }

}
