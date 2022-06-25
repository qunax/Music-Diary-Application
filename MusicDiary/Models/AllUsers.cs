using MusicDiary.Exceptions;
using MusicDiary.Services.ConflictValidators;
using MusicDiary.Services.Creators;
using MusicDiary.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Models
{
    public class AllUsers
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserCreator _userCreator;
        private readonly IRegistrationConflictValidator _registrationConflictValidator;


        public AllUsers(IUserProvider userProvider, IUserCreator userCreator, IRegistrationConflictValidator registrationConflictValidator)
        {
            _userProvider = userProvider;
            _userCreator = userCreator;
            _registrationConflictValidator = registrationConflictValidator;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userProvider.GetAllUsers();
        }

        public async Task CreateUser(User user)
        {
            User conflictingRegistration = await _registrationConflictValidator.GetConflictingRegistration(user);

            if (conflictingRegistration != null)
            {
                throw new RegistrationConflictException(conflictingRegistration, user);
            }

            await _userCreator.CreateUser(user);
        }
    }
}
