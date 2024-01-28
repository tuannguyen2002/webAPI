using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using webAPI.Data.Base;
using webAPI.Data.DangNhap;

namespace webAPI.Data.HoaDon
{
    public class hoadon : baseEntity
    {
        public Guid UserId { get; set; }
        public User Users { get; set; }


        public DateTime thoigianban { get; set; }

        public int tongtien { get; set; }

        public string ghichu { get; set; }

        public ICollection<chitiethoadon> chitiethoadons { get; set; }
    }
}
