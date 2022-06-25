using MusicDiary.Services.Creators;
using MusicDiary.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class AllTracks
    {
        private readonly ITrackProvider _trackProvider;
        private readonly ITrackCreator _trackCreator;


        public AllTracks(ITrackProvider trackProvider, ITrackCreator trackCreator)
        {
            _trackProvider = trackProvider;
            _trackCreator = trackCreator;
        }


        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            return await _trackProvider.GetAllTracks();
        }

        public async Task AddTrack(Track track)
        {
            await _trackCreator.CreateTrack(track);
        }
    }
}
