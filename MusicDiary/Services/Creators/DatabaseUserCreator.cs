using MusicDiary.DBContexts;
using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services.Creators
{
    public class DatabaseUserCreator : IUserCreator
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseUserCreator(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateUser(User user)
        {
           using(MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
