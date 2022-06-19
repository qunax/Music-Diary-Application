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
    class LikedAlbumsViewModel : ViewModelBase
    {
        public ICommand BackCommand { get; }


        public LikedAlbumsViewModel(NavigationService homePageNavigationSErvice)
        {
            BackCommand = new NavigateCommand(homePageNavigationSErvice);
        }
    }
}
