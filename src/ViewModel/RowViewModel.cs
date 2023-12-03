using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RowViewModel
    {
        public IEnumerable<SquareViewModel> Squares { get; }

        public RowViewModel(IEnumerable<Square> squares, ICell<IGame> game, int rowIndex)
        {
            // Derive a cell for the game board from the game cell
            ICell<IGameBoard> gameBoard = game.Derive(g => g.Board);

            // Create a collection of SquareViewModels for each square in the row
            Squares = squares.Select((s, i) =>
                new SquareViewModel(game, new Vector2D(i, rowIndex)));
        }

    }

}
