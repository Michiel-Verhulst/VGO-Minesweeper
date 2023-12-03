using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly ICell<IGame> game;
        public IEnumerable<RowViewModel> Rows { get; }

        public GameBoardViewModel(ICell<IGame> game)
        {
            this.game = game;

            // Derive a cell for the game board from the game cell
            ICell<IGameBoard> gameBoard = game.Derive(g => g.Board);

            // Create a collection of RowViewModels for each row in the game board
            Rows = Enumerable.Range(0, gameBoard.Value.Height)
                .Select(row => new RowViewModel(
                    // Create a collection of CellViewModels for each column in the row
                    Enumerable.Range(0, gameBoard.Value.Width)
                        .Select(column => gameBoard.Value[new Vector2D(column, row)]),
                    game,
                    row
                ));
        }


    }

}
