using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using MusicDiary.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services
{
    class DatabaseTrackProvider : ITrackProvider
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseTrackProvider(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            using(MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Tracks.ToListAsync();
            }
        }
    }
}
