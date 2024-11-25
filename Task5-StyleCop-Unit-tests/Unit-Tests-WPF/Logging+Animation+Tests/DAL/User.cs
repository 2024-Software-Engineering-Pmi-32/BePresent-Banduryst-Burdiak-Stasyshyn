namespace bepresent_wpf.DAL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Documents;
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
