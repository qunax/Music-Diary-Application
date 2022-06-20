using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Commands
{
    public class AddNewTrackCommand : CommandBase
    {
        private AddTrackViewModel _addTrackViewModel;
        private readonly NavigationService _mainMenunavigationService;

        public AddNewTrackCommand(AddTrackViewModel addTrackViewModel, NavigationService mainMenuNavigationService)
        {
            _addTrackViewModel = addTrackViewModel;
            _addTrackViewModel.PropertyChanged += OnViewPropertyChanged;
            _mainMenunavigationService = mainMenuNavigationService;
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddTrackViewModel.TrackTitle) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackGenre) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackAlbumName) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackArtistName) ||
                e.PropertyName == nameof(AddTrackViewModel.TrackTextLink))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addTrackViewModel.TrackTitle)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackGenre)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackAlbumName)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackArtistName)
                && !string.IsNullOrEmpty(_addTrackViewModel.TrackTextLink)
                && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _mainMenunavigationService.Navigate();
        }
    }
}
