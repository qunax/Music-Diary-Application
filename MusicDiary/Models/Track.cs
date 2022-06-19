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
        public Album Album { get; set; }
        public Artist Artist { get; set; }

        public string Cover { get; set; }

    }
}
