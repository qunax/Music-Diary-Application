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

        public Artist(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string InfoAbout { get; set; }
        public string Avatar { get; set; }


        
    }
}
