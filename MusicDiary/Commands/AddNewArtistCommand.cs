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
    public class AddNewArtistCommand : CommandBase
    {
        private AddArtistViewModel _addArtistViewModel;
        private readonly NavigationService _mainMenuNavigationService;



        public AddNewArtistCommand(AddArtistViewModel addArtistViewModel, NavigationService mainMenuNavigationService)
        {
            _addArtistViewModel = addArtistViewModel;
            _addArtistViewModel.PropertyChanged += OnViewPropertyChanged;
            _mainMenuNavigationService = mainMenuNavigationService;
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddArtistViewModel.ArtistName))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addArtistViewModel.ArtistName)
                && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _mainMenuNavigationService.Navigate();
        }
    }
}
