using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using KBVB.AR.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;
using System.Diagnostics;
using Xamarin.Forms;
using KBVB.AR.Services;
using System.Linq;
using Rg.Plugins.Popup.Services;
using KBVB.AR.Views;
using GalaSoft.MvvmLight.Messaging;
using KBVB.AR.Messages;
using KBVB.AR.Data;

namespace KBVB.AR.ViewModels
{
    public class HomeViewModel : ViewModelBase, IObserver
    {
        private readonly INavigationServiceWithInit _navigationService;

        private CurrentChosenPlayer _currentChosenPlayer;
        public ICommand SelectCommand { get; set; }
        public ICommand InfoCommand { get; set; }
        public ICommand NavigateToGalleryCommand { get; set; }
        private ObservableCollection<Player> _playersList;
        public ObservableCollection<Player> PlayersList
        {
            get => _playersList;
            set => Set(() => PlayersList, ref _playersList, value);
        }

        private int _index;

        public  int Index
        {
            get => _index;
            set
            {
                Set(() => Index, ref _index, value);
                _currentChosenPlayer.NotifyObservers(value);
            }
        }

        public HomeViewModel(INavigationServiceWithInit navigationService, IPlayerDataService playerDataService)
        {
            _navigationService = navigationService;
            NavigateToGalleryCommand = new RelayCommand(NavigateToGallery);
            SelectCommand            = new RelayCommand(SelectPlayer);
            InfoCommand              = new RelayCommand(ShowPlayerInfo);
            PlayersList = new ObservableCollection<Player>(playerDataService.GetAllPlayers().OrderBy(p=>p.Name));           
            
            _currentChosenPlayer = new CurrentChosenPlayer();
            _currentChosenPlayer.RegisterObserver(this);
            Index = 0;
        }

		public void ShowPlayerInfo()
        {
            PopupNavigation.Instance.PushAsync((Rg.Plugins.Popup.Pages.PopupPage)new PlayerInfoView());
            PlayersMessage players = new PlayersMessage
            {
                ObservableCollectionPlayers = _playersList,
                Index = _index,
                CurrentChosenPlayer = _currentChosenPlayer
            };
            Messenger.Default.Send<PlayersMessage>(players);
        }

        private void NavigateToGallery()
        {
            Debug.WriteLine("navigate to gallery.");
            _navigationService.NavigateTo(ViewModelLocator.GalleryView);
        }

        private void SelectPlayer()
        {
            Debug.WriteLine("SelectPlayer button is pushed.");
            Debug.WriteLine("Selected Player is " + _playersList[_index].Name);

            // TODO: Enable when the next view is availlable
            // You can use either player.Name or player.ImageUrl what suits best for you.
            //_navigationService.NavigateTo()
        }

        public void Update(int index)
        {
            Debug.WriteLine(index + " observer");
            if(Index != index)
            {
                Index = index;
            }
        }
    }
}
