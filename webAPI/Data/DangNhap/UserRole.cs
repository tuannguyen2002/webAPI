using System.ComponentModel.DataAnnotations;
using webAPI.Data.HoaDon;

namespace webAPI.Data.DangNhap
{
    public class UserRole
    {
        [Key]
        public string roleID { get; set; }
        public string roleName { get; set; }
        public string note { get; set; }
        public ICollection<User> users { get; set; }
    }
}
