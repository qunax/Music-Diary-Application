using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using MusicDiary.Services.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services
{
    class DatabaseTrackCreator : ITrackCreator
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseTrackCreator(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateTrack(Track track)
        {
            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Tracks.Add(track);
                await context.SaveChangesAsync();
            }
        }
    }
}
