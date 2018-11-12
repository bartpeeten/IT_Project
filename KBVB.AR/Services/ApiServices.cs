using System;
using System.Net.Http;
using KBVB.AR.Models;

namespace KBVB.AR.Services
{
    public class ApiServices
    {
        private readonly HttpClient _client;
        //private static readonly string BASEADDRESS = "http://eventprojectapi.azurewebsites.net/api/";

        public ApiServices()
        {
            _client = new HttpClient();
        }
       

        public void GetPlayerInfo(Player player)
        {
            

        }
    
    }
}
