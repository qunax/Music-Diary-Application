using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        private readonly Track _track;

        public string TrackName => _track.Name;
        public string TrackGenre => _track.Genre;
        public string YearOfTrack => _track.Year.ToString();
        public string ArtistOfTrack => _track.Artist.Name.ToString();

        public string TrackCover => _track?.Cover;


        public TrackViewModel(Track track)
        {
            _track = track;
        }
    }
}
