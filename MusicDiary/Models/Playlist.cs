using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Playlist
    {
        private readonly List<Track> _tracks;


        public string Name { get; set; }
        public string Cover { get; set; }

        public Playlist(string name)
        {
            Name = name;

            _tracks = new List<Track>();
        }


        public IEnumerable<Track> GetAllTracks()
        {
            return _tracks;
        }

        public void AddTrack(Track track)
        {
            _tracks.Add(track);
        }

        public void DeleteTrack(Track track)
        {
            _tracks.Remove(track);
        }
    }
}
