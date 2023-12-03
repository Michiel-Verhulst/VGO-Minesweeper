using Cells;
using Model.MineSweeper;
using System.Diagnostics;
using System.Windows.Input;
using ViewModel.Commands;
using ViewModel.ScreenViewModels;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel : ScreenViewModel
    {
        public ICell<IGame> game { get; }

        public GameBoardViewModel Board { get; }

        public ICell<GameStatus> Status => game.Derive(g => g.Status);

        public ICommand ExitGameCommand { get; }

        public ICell<TimeSpan> Counter { get; }

        public GameViewModel(IGame game, ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            this.game = Cell.Create(game);

            // Create a GameBoardViewModel for the game board using the game cell
            Board = new GameBoardViewModel(this.game);

            // Create an ActionCommand for the ExitGameCommand, which sets the CurrentScreen to a new SettingsScreenViewModel
            ExitGameCommand = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(game, CurrentScreen));

            // Create a Cell<TimeSpan> for the Counter, initially set to TimeSpan.Zero
            Counter = Cell.Create(TimeSpan.Zero);

            // Create a timer to update the Counter every second
            var second = new System.Timers.Timer();
            second.Interval = 1000;
            second.Elapsed += (sender, e) =>
            {
                // Check if the game status is InProgress
                if (Status.Value == GameStatus.InProgress)
                {
                    // Increment the Counter by one second
                    Counter.Value = Counter.Value.Add(TimeSpan.FromSeconds(1));
                }
                else
                {
                    // Stop the timer if the game status is not InProgress
                    second.Stop();
                }
            };
            second.Start();
        }

    }
}

