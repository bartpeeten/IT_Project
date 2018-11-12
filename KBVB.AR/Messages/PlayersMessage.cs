using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KBVB.AR.Messages
{
    public class PlayersMessage
    {
        public ObservableCollection<Player> ObservableCollectionPlayers { get; set; }
        public int Index { get; set; }
        public CurrentChosenPlayer CurrentChosenPlayer { get; set; }
    }
}
