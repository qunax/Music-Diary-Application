using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services.ConflictValidators
{
    public interface IRegistrationConflictValidator
    {
        Task<User> GetConflictingRegistration(User user);
    }
}
