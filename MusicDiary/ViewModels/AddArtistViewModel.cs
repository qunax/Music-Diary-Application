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
    public class AddArtistViewModel : ViewModelBase
    {
        private string _artistAvatar;
        public string ArtistAvatar
        {
            get
            {
                return _artistAvatar;
            }
            set
            {
                _artistAvatar = value;
                OnPropertyChanged(nameof(ArtistAvatar));
            }
        }

        private string _artistName;
        public string ArtistName
        {
            get
            {
                return _artistName;
            }
            set
            {
                _artistName = value;
                OnPropertyChanged(nameof(ArtistName));
            }
        }

        private string _artistInfo;
        public string ArtistInfo
        {
            get
            {
                return _artistInfo;
            }
            set
            {
                _artistInfo = value;
                OnPropertyChanged(nameof(ArtistInfo));
            }
        }


        public ICommand AddAvatar { get; }
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public AddArtistViewModel(NavigationService mainMenuNavigationService)
        {
            CancelCommand = new NavigateCommand(mainMenuNavigationService);
            SubmitCommand = new AddNewArtistCommand(this, mainMenuNavigationService);
        }
    }
}
