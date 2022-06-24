using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Artist
    {
        private readonly List<Track> _tracks;


        public string Name { get; set; }
        public string InfoAbout { get; set; }
        public string Avatar { get; set; }


        public Artist(string name)
        {
            _tracks = new List<Track>();

            Name = name;
        }
    }
}
