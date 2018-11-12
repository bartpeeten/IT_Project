using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using KBVB.AR.Messages;
using KBVB.AR.Models;
using KBVB.AR.Services;
using KBVB.AR.Views;

namespace KBVB.AR.ViewModels
{
    public class PlayerInfoViewModel : ViewModelBase, IObserver
    {
        // Global variables, Properties.
        private readonly INavigationServiceWithInit _navigationService;
        public ICommand CloseCommand;
        public ICommand DecrementCommand { get; set; }
        public ICommand IncrementCommand { get; set; }
        private ObservableCollection<Player> _playersList;
        private int _index;
        private CurrentChosenPlayer _currentChosenPlayer;
        private Player _player;
        private ApiServices _apiServices;

        public Player Player
        {
            get => _player;
            set
            {
                Set(() => Player, ref _player, value);
                _currentChosenPlayer.NotifyObservers(_index);
            }
        }


		// Constructor.
		public PlayerInfoViewModel(INavigationServiceWithInit navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<PlayersMessage>(this, (message) => InitVariables(message));
            CloseCommand       = new RelayCommand(ClosePopup);
            DecrementCommand = new RelayCommand(DecrementIndex);
            IncrementCommand = new RelayCommand(IncrementIndex);
            _apiServices       = new ApiServices();
        }

        private void IncrementIndex()
        {
            if(_index < _playersList.Count-1)
            {
                _index++;
                Player = _playersList[_index];
            }
        }

        private void DecrementIndex()
        {
            if(_index > 0)
            {
                _index--;
                Player = _playersList[_index];
            }
        }

        private void InitVariables(PlayersMessage message)
        {
            _currentChosenPlayer = message.CurrentChosenPlayer;
            _currentChosenPlayer.RegisterObserver(this);
            _playersList = message.ObservableCollectionPlayers;
            _index = message.Index;
            Player = _playersList[_index];

        }

        private void ClosePopup()
        {
            _currentChosenPlayer.UnregisterObserver(this);
            _navigationService.NavigateTo(ViewModelLocator.HomeView);
        }

        public void Update(int index)
        {
           //no implementation needed
        }
    }
}
