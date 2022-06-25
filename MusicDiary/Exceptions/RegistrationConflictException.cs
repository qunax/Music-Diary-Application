using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Exceptions
{
    public class RegistrationConflictException : Exception
    {
        public User ExistingUser { get; }
        public User IncomingUser { get; }

        public RegistrationConflictException(User existingUser = null, User incomingUser = null)
        {
            ExistingUser = existingUser;
            IncomingUser = incomingUser;
        }

        public RegistrationConflictException(string message, User existingUser, User incomingUser) : base(message)
        {
            ExistingUser = existingUser;
            IncomingUser = incomingUser;
        }

        public RegistrationConflictException(string message, Exception innerException, User existingUser, User incomingUser) : base(message, innerException)
        {
            ExistingUser = existingUser;
            IncomingUser = incomingUser;
        }

    }
}
