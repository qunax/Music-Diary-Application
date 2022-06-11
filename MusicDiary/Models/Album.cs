using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Album
    {
        private readonly List<Track> _tracks;


        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int YearOfCreation { get; set; }

        public int TrackCount
        {
            get { return _tracks.Count; }
        }

        public string InfoAbout { get; set; }


        public Album(string name, Artist artist, int yearOfCreation, string infoAbout)
        {
            Name = name;
            Artist = artist;
            YearOfCreation = yearOfCreation;
            InfoAbout = infoAbout;

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
