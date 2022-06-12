using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Commands
{
    public class MakeRegistrationCommand : CommandBase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private readonly NavigationService _autorizationFormNavigationService;



        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, NavigationService autorizationFormNavigationService)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;

            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;

            _autorizationFormNavigationService = autorizationFormNavigationService;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeRegistrationViewModel.NewUsername) ||
                e.PropertyName == nameof(MakeRegistrationViewModel.NewPassword) ||
                e.PropertyName == nameof(MakeRegistrationViewModel.RepeatPassword) ||
                e.PropertyName == nameof(MakeRegistrationViewModel.Email))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeRegistrationViewModel.NewUsername )
                && !string.IsNullOrEmpty(_makeRegistrationViewModel.NewPassword)
                && !string.IsNullOrEmpty(_makeRegistrationViewModel.RepeatPassword)
                && !string.IsNullOrEmpty(_makeRegistrationViewModel.Email) 
                && base.CanExecute(parameter);
        }


        public override void Execute(object parameter)
        {
            User user = new User();

            user.UserName = _makeRegistrationViewModel.NewUsername;
            user.PassWord = _makeRegistrationViewModel.NewPassword;
            user.Email = _makeRegistrationViewModel.Email;


            _autorizationFormNavigationService.Navigate();
        }
    }
}
