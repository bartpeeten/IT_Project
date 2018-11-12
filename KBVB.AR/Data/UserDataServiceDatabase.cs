using KBVB.AR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KBVB.AR.Data
{
    public class UserDataServiceDatabase : IUserDataService
    {
        private const string baseUrl = "http://kbvk-ar.azurewebsites.net/api/users";

        public User GetUserByEmail(string email)
        {           
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(baseUrl);
                var response = "";
                Task task = Task.Run(async () => { response = await client.GetStringAsync(uri); });
                task.Wait();
                var allUsers = JsonConvert.DeserializeObject<List<User>>(response);

                return allUsers.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            }
        }
    }
}
