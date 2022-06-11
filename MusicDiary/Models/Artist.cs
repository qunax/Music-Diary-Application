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
        private readonly List<Album> _albums;


        public string Name { get; set; }
        public string InfoAbout { get; set; }

    }
}
