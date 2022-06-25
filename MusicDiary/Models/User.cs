using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class User
    {




        private readonly List<Track> _tracks;
        private readonly List<Playlist> _playlists;
        private readonly List<Artist> _artists;




        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }




        public bool Conflicts(User user)
        {
            if(user.Username != Username)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
