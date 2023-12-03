using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ScreenViewModels
{
    public class ScreenViewModel
    {
        protected ICell<ScreenViewModel> CurrentScreen { get; }

        protected ScreenViewModel(ICell<ScreenViewModel> currentScreen)
            {
                this.CurrentScreen = currentScreen;
            }
    }
}
