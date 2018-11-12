using KBVB.AR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.AR.Data
{
    public static class MockDataBuilder
    {
        public static List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>
            {
                new User
                {
                    Email = "test@email.com",
                    Password = "test123"
                },
                new User
                {
                    Email = "fakeUser@email.be",
                    Password = "fake789"
                }
            };

            return allUsers;
        }

        public static List<Player> GetAllPlayers()
        {
            List<Player> allPlayers = new List<Player>
            {
                new Player
                {
                    Name = "Toby Alderweireld",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/5257.jpg",
                    BirthDate = new DateTime(1989,03,02),
                    Club = "Tottenham Hotspur",
                    DoYouKnow = "Something interesting about this player"                    
                },
                new Player
                {
                    Name = "Michy Batshuayi",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/6211.jpg",
                    BirthDate = new DateTime(1993,10,02),
                    Club = "Borussia Dortmund",
                    DoYouKnow = "Something interesting about this player"
                },
                new Player
                {
                    Name = "Christian Benteke",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/5621.jpg",
                    BirthDate = new DateTime(1990,12,03),
                    Club = "Crystal Palace",
                    DoYouKnow = "Something interesting about this player"
                },
                new Player
                {
                    Name = "Thibaut Courtois",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/5771.jpg",
                    BirthDate = new DateTime(1992,05,11),
                    Club = "Chelsea",
                    DoYouKnow = "Something interesting about this player"
                },
                new Player
                {
                    Name = "Kevin De Bruyne",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/5733.jpg",
                    BirthDate = new DateTime(1991,06,28),
                    Club = "Manchester City",
                    DoYouKnow = "Something interesting about this player"
                },
                new Player
                {
                    Name = "Mousa Dembélé",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/5138.jpg",
                    BirthDate = new DateTime(1987,07,16),
                    Club = "Tottenham Hotspur",
                    DoYouKnow = "Something interesting about this player"
                },
                new Player
                {
                    Name = "Eden Hazard",
                    ImageUrl = "http://static.belgianfootball.be/project/publiek/internationals/footmen/5464.jpg",
                    BirthDate = new DateTime(1991,01,07),
                    Club = "Chelsea",
                    DoYouKnow = "Something interesting about this player"
                }
            };

            return allPlayers;
        }

        public static List<Picture> GetFakePictures()
        {
            List<Picture> pictures = new List<Picture>();

            for (int i = 0; i < 5; i++)
            {
                Picture picture1 = new Picture()
                {
                    ImageUrl = "https://dsocdn.akamaized.net/Assets/Images_Upload/2014/05/27/Selfie.jpg?maxheight=416&maxwidth=568&scale=both"
                };
                Picture picture2 = new Picture()
                {
                    ImageUrl = "http://sportmagazine.knack.be/medias/2482/1270957.jpg"
                };

                pictures.Add(picture1);
                pictures.Add(picture2);
            }

            return pictures;
        }
    }   
}
