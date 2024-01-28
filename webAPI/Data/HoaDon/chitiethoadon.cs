using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webAPI.Data.Base;
using webAPI.Data.Sach;

namespace webAPI.Data.HoaDon
{
    public class chitiethoadon : baseEntity
    {
        //Khóa ngoại của bảng hoadon
        public Guid hoadonID { get; set; }
        public hoadon hoadon { get; set; }


        //Khóa ngoại bảng sach
        public Guid sachID { get; set; }
        public sach sach { get; set; }


        public int soluong { get; set; }

        public int giaban { get; set; }

        public string ghichu { get; set; }
    }
}
