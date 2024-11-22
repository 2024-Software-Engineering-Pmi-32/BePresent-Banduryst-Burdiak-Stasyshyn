using bepresent_wpf.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace bepresent_wpf.DAL
{
    public class Gift
    {
        [Key]
        public int gift_id { get; set; }
        public int board_id { get; set; } 
        public string name { get; set; } 
        public string description { get; set; } 
        public string link { get; set; }
        public string image_url { get; set; } 
        public bool is_reserved { get; set; } = false; 
        public int? reserved_by { get; set; } 
        public DateTime created_at { get; set; } = DateTime.UtcNow; 

    }
}