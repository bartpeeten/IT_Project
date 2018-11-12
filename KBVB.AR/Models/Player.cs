using System;
namespace KBVB.AR.Models
{
    public class Player
    {
        public String Name
        {
            get;
            set;
        }

        public String ImageUrl
        {
            get;
            set;
        }

        public string DoYouKnow { get; set; }
        public DateTime BirthDate { get; set; }
        public string Club { get; set; }
    }
}
