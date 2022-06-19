using MusicDiary.Commands;
using MusicDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    class AddTrackViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public AddTrackViewModel(NavigationService mainMenuNavigationService)
        {
            CancelCommand = new NavigateCommand(mainMenuNavigationService);
        }
    }
}
