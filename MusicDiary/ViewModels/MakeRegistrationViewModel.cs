using MusicDiary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    class MakeRegistrationViewModel : ViewModelBase
    {
        private string _newUsername;
        public string NewUsername
        {
            get
            {
                return _newUsername;
            }
            set
            {
                _newUsername = value;
                OnPropertyChanged(nameof(NewUsername));
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }


        private string _repeatPassword;
        public string RepeatPassword
        {
            get
            {
                return _repeatPassword;
            }
            set
            {
                _repeatPassword = value;
                OnPropertyChanged(nameof(RepeatPassword));
            }
        }


        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        public ICommand FinishTheRegistrationCommand { get; }
        public ICommand BackToAutorizationFromCommand { get; }


        public MakeRegistrationViewModel()
        {
            FinishTheRegistrationCommand = new MakeRegistrationCommand(this);
        }
    }
}
