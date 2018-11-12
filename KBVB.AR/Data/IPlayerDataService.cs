using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Data
{
    public interface IPlayerDataService
    {
        List<Player> GetAllPlayers();
        Player GetPlayerByName(string name);
    }
}
