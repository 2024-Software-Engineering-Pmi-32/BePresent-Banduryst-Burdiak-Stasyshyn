using bepresent_wpf.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace bepresent_wpf.BLL
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }

    public class BoardDTO
    {
        public int board_id { get; set; } 
        public int user_id { get; set; }
        public string name { get; set; }
        public DateTime? celebration_date { get; set; } 
        public int[] collaborators { get; set; } 
        public string access_level { get; set; } 
        public string description { get; set; } 
        public DateTime created_at { get; set; } 
    }


    public class GiftDTO
    {
        public int gift_id { get; set; } 
        public string name { get; set; } 
        public string description { get; set; } 
        public string link { get; set; } 
        public string image_url { get; set; } 
        public bool is_reserved { get; set; } 
        public DateTime created_at { get; set; } 
    }
}