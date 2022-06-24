using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class Track
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public Artist Artist { get; set; }

        public string Cover { get; set; }


        public Track(string name, string genre, int year, Artist artist)
        {
            Name = name;
            Genre = genre;
            Year = year;
            Artist = artist;
        }

    }
}
