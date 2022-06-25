using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services.Providers
{
    public interface IUserProvider
    {
        Task<List<User>> GetAllUsers();
    }
}
