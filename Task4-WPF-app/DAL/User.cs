using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Documents;

namespace bepresent_wpf.DAL
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; } 
    }
}
