using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Data
{
    public class PlayerDataServiceMocked : IPlayerDataService
    {
        private List<Player> _allPlayers;

        public PlayerDataServiceMocked()
        {
            _allPlayers = MockDataBuilder.GetAllPlayers();
        }
        public List<Player> GetAllPlayers()
        {
            return _allPlayers;
        }

        public Player GetPlayerByName(string name)
        {
            return _allPlayers.Find(p => p.Name.Equals(name));
        }
    }
}
