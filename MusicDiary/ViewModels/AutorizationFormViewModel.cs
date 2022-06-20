using MusicDiary.Commands;
using MusicDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    public class AutorizationFormViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LogInCommand { get; } 
        public ICommand HaveNoAccountCommand { get; }

        public AutorizationFormViewModel(NavigationService makeRegistrationNavigationService, NavigationService mainMenuNavigationService)
        {
            LogInCommand = new LogInCommand(this, mainMenuNavigationService);
            HaveNoAccountCommand = new NavigateCommand(makeRegistrationNavigationService);
        }
    }
}
