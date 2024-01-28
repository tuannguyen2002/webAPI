using System.ComponentModel.DataAnnotations;
using webAPI.Data.Base;
using webAPI.Data.HoaDon;

namespace webAPI.Data.DangNhap
{
    public class User : baseEntity
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public string roleID { get; set; }
        public UserRole Roles { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public ICollection<hoadon> hoadons { get; set; }
    }
}
