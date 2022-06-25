using MusicDiary.Exceptions;
using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary.Commands
{
    public class MakeRegistrationCommand : CommandBase
    {
        private MakeRegistrationViewModel _makeRegistrationViewModel;
        private readonly NavigationService _autorizationFormNavigationService;
        private readonly AllUsers _allUsers;



        public MakeRegistrationCommand(MakeRegistrationViewModel makeRegistrationViewModel, NavigationService autorizationFormNavigationService, AllUsers allUsers)
        {
            _makeRegistrationViewModel = makeRegistrationViewModel;

            _makeRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;

            _autorizationFormNavigationService = autorizationFormNavigationService;

            _allUsers = allUsers;
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


        public override async void Execute(object parameter)
        {
            if(_makeRegistrationViewModel.NewPassword != _makeRegistrationViewModel.RepeatPassword)
            {
                MessageBox.Show("Repeated password isn't correct. Try again.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                
            }

            User user = new User();

            user.Username = _makeRegistrationViewModel.NewUsername;
            user.Password = _makeRegistrationViewModel.NewPassword;
            user.Email = _makeRegistrationViewModel.Email;

            try
            {
                await _allUsers.CreateUser(user);
                _autorizationFormNavigationService.Navigate();
            }
            catch (RegistrationConflictException)
            {
                MessageBox.Show("This Username is already taken", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to make registration.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
