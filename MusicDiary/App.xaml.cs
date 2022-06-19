using MusicDiary.Services;
using MusicDiary.Stores;
using MusicDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDiary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationStore _innerNavigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _innerNavigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateAutorizationFormViewModel();
            _innerNavigationStore.CurrentViewModel = CreateHomePageViewModel();

            MainWindow = new MainWindow()
            { 
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            

            base.OnStartup(e);
        }

        private MakeRegistrationViewModel CreateMakeRegistrationViewModel()
        {
            return new MakeRegistrationViewModel(new NavigationService(_navigationStore, CreateAutorizationFormViewModel));
        }

        private AutorizationFormViewModel CreateAutorizationFormViewModel()
        {
            return new AutorizationFormViewModel(new NavigationService(_navigationStore, CreateMakeRegistrationViewModel),
                new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(_innerNavigationStore,
                new NavigationService(_innerNavigationStore, CreateLikedTracksViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedArtistsViewModel),
                new NavigationService(_innerNavigationStore, CreateLikedAlbumsViewModel));
        }

        private HomePageViewModel CreateHomePageViewModel()
        {
            return new HomePageViewModel();
        }

        private LikedTracksViewModel CreateLikedTracksViewModel()
        {
            return new LikedTracksViewModel(new NavigationService(_innerNavigationStore, CreateHomePageViewModel), new NavigationService(_navigationStore, CreateAddTrackViewModel));
        }
        
        private LikedArtistsViewModel CreateLikedArtistsViewModel()
        {
            return new LikedArtistsViewModel(new NavigationService(_innerNavigationStore, CreateHomePageViewModel));
        }

        private LikedAlbumsViewModel CreateLikedAlbumsViewModel()
        {
            return new LikedAlbumsViewModel(new NavigationService(_innerNavigationStore, CreateHomePageViewModel));
        }      
        

        private AddTrackViewModel CreateAddTrackViewModel()
        {
            return new AddTrackViewModel(new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
    }
}
