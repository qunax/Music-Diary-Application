using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services.ConflictValidators
{
    class DatabaseRegistrationConflictValidator : IRegistrationConflictValidator
    {
        private readonly MusicDiaryDbContextFactory _dbContextFactory;

        public DatabaseRegistrationConflictValidator(MusicDiaryDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public async Task<User> GetConflictingRegistration(User user)
        {
            using(MusicDiaryDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Users.Where(u => u.Username == user.Username).FirstOrDefaultAsync();
            }
        }
    }
}
