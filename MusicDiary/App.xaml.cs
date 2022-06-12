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

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMakeRegistrationViewModel();

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
            return new MainMenuViewModel();
        }
    }
}
