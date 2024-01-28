using System.ComponentModel.DataAnnotations.Schema;
using webAPI.Data.DangNhap;

namespace webAPI.Models
{
    public class userModel
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public string roleID { get; set; }
        [ForeignKey("roleID")]
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
