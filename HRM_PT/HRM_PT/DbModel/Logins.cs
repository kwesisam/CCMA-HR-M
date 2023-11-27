using SQLite;

namespace HRM_PT.DbModel
{
    [Table("logins_tb")]
    public class Logins
    {
        [PrimaryKey, Unique]
        public string staffID { get; set; }

        [MaxLength(100)]
        public string firstName { get; set; }

        [MaxLength(100)]
        public string surname { get; set; }

        [MaxLength(50)]
        public string password { get; set; }

    }
}
