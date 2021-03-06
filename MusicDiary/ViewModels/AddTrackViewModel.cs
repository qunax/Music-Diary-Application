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
    public class AddTrackViewModel : ViewModelBase
    {
        private string _trackTitle;

        private string _trackCover;
        public string TrackCover
        {
            get
            {
                return _trackCover;
            }
            set
            {
                _trackCover = value;
                OnPropertyChanged(nameof(TrackCover));
            }
        }

        public string TrackTitle
        {
            get
            {
                return _trackTitle;
            }
            set
            {
                _trackTitle = value;
                OnPropertyChanged(nameof(TrackTitle));
            }
        }

        private string _trackGenre;
        public string TrackGenre
        {
            get
            {
                return _trackGenre;
            }
            set
            {
                _trackGenre = value;
                OnPropertyChanged(nameof(TrackGenre));
            }
        }

        private string _trackAlbumname;
        public string TrackAlbumName
        {
            get
            {
                return _trackAlbumname;
            }
            set
            {
                _trackAlbumname = value;
                OnPropertyChanged(nameof(TrackAlbumName));
            }
        }

        private string _trackArtistName;
        public string TrackArtistName
        {
            get
            {
                return _trackArtistName;
            }
            set
            {
                _trackArtistName = value;
                OnPropertyChanged(nameof(TrackArtistName));
            }
        }

        private string _trackText;
        public string TrackText
        {
            get
            {
                return _trackText;
            }
            set
            {
                _trackText = value;
                OnPropertyChanged(nameof(TrackText));
            }
        }



        public ICommand AddCover { get; }
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public AddTrackViewModel(NavigationService mainMenuNavigationService)
        {
            CancelCommand = new NavigateCommand(mainMenuNavigationService);
            SubmitCommand = new AddNewTrackCommand(this, mainMenuNavigationService);
        }
    }
}
