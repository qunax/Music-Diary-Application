using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MusicDiary.ViewModels
{
    class LikedTracksViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TrackViewModel> _tracks;

        public IEnumerable<TrackViewModel> Tracks => _tracks;


        public ICommand BackCommand { get; }
        public ICommand AddTrackCommand { get; }


        public LikedTracksViewModel(NavigationService homePageNavigationSErvice, NavigationService addTrackNavigationService)
        {
            _tracks = new ObservableCollection<TrackViewModel>();
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));
            _tracks.Add(new TrackViewModel(new Track("NAME", "genre", 2015, new Artist("artist"))));


            BackCommand = new NavigateCommand(homePageNavigationSErvice);
            AddTrackCommand = new NavigateCommand(addTrackNavigationService);
        }
    }
}
