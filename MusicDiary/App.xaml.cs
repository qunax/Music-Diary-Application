using Microsoft.EntityFrameworkCore;
using MusicDiary.DBContexts;
using MusicDiary.Models;
using MusicDiary.Services;
using MusicDiary.Services.ConflictValidators;
using MusicDiary.Services.Creators;
using MusicDiary.Services.Providers;
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
        private const string CONNECTION_STRING = "Data Source=musicDiary.db";

        private readonly AllUsers _allUsers;

        private readonly NavigationStore _navigationStore;
        private readonly NavigationStore _innerNavigationStore;

        private readonly MusicDiaryDbContextFactory _musicDiaryDbContextFactory;

        public App()
        {
            _navigationStore = new NavigationStore();
            _innerNavigationStore = new NavigationStore();

            _musicDiaryDbContextFactory = new MusicDiaryDbContextFactory(CONNECTION_STRING);

            IUserProvider userProvider = new DatabaseUserProvider(_musicDiaryDbContextFactory);
            IUserCreator userCreator = new DatabaseUserCreator(_musicDiaryDbContextFactory);
            IRegistrationConflictValidator registrationConflictValidator = new DatabaseRegistrationConflictValidator(_musicDiaryDbContextFactory);
            _allUsers = new AllUsers(userProvider, userCreator, registrationConflictValidator);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            using (MusicDiaryDbContext dbContext = _musicDiaryDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }


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
            return new MakeRegistrationViewModel(new NavigationService(_navigationStore, CreateAutorizationFormViewModel), _allUsers);
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
            return new LikedArtistsViewModel(new NavigationService(_innerNavigationStore, CreateHomePageViewModel), new NavigationService(_navigationStore, CreateAddArtistViewModel));
        }

        private MyPlaylistsViewModel CreateLikedAlbumsViewModel()
        {
            return new MyPlaylistsViewModel(new NavigationService(_innerNavigationStore, CreateHomePageViewModel), new NavigationService(_navigationStore, CreateMakePlaylistViewModel));
        }      
        

        private AddTrackViewModel CreateAddTrackViewModel()
        {
            return new AddTrackViewModel(new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private AddArtistViewModel CreateAddArtistViewModel()
        {
            return new AddArtistViewModel(new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }

        private MakePlaylistViewModel CreateMakePlaylistViewModel()
        {
            return new MakePlaylistViewModel(new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
    }
}
