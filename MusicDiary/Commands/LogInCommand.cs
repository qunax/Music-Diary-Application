using MusicDiary.Services;
using MusicDiary.Stores;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Commands
{
    public class LogInCommand : CommandBase
    {
        private AutorizationFormViewModel _autorizationFormViewModel;
        private readonly NavigationService _mainMenuNavigationService;


        public LogInCommand(AutorizationFormViewModel autorizationFormViewModel, NavigationService mainMenuNavigationStore)
        {
            _autorizationFormViewModel = autorizationFormViewModel;
            _autorizationFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _mainMenuNavigationService = mainMenuNavigationStore;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AutorizationFormViewModel.Username) ||
                e.PropertyName == nameof(AutorizationFormViewModel.Password))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_autorizationFormViewModel.Username) 
                && !string.IsNullOrEmpty(_autorizationFormViewModel.Password)
                && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _mainMenuNavigationService.Navigate();
        }
    }
}
