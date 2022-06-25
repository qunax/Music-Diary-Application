using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services.Providers
{
    class DatabaseUserProvider : IUserProvider
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseUserProvider(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<User>> GetAllUsers()
        {

            using (MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}
