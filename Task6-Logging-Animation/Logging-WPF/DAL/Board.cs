﻿namespace bepresent_wpf.DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Board
    {
        [Key]
        public int board_id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }

        public DateTime? celebration_date { get; set; }
        public int[] collaborators { get; set; }
        public string access_level { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
