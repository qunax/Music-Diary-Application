using MusicDiary.Commands;
using MusicDiary.Models;
using MusicDiary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicDiary.ViewModels
{
    class LikedArtistsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ArtistViewModel> _artists;



        public IEnumerable<ArtistViewModel> Artists => _artists;



        public ICommand BackCommand { get; }
        public ICommand AddArtistCommand { get; } 


        public LikedArtistsViewModel(NavigationService homePageNavigationSErvice, NavigationService addArtistNavigationService)
        {
            _artists = new ObservableCollection<ArtistViewModel>();
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));
            _artists.Add(new ArtistViewModel(new Artist("NF")));


            BackCommand = new NavigateCommand(homePageNavigationSErvice);
            AddArtistCommand = new NavigateCommand(addArtistNavigationService);
        }
    }
}
