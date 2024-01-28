using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webAPI.Data.Base;
using webAPI.Data.HoaDon;
using webAPI.Data.Nguon;

namespace webAPI.Data.Sach
{
    public class sach : baseEntity
    {
        public string tensach { get; set; }


        //Khóa ngoại bảng tacgia
        public Guid tacgiaID { get; set; }
        public tacgia tacgia { get; set; }


        //khóa ngoại bảng nhaxuatban
        public Guid nhaxbID { get; set; }
        public nhaxb nhaxuatban { get; set; }

        
        public int giaban { get; set; }

        public int soluong { get; set; }

        public string ghichu { get; set; }

        public ICollection<theloai_sach> theloai_Saches { get; set; }

        public ICollection<chitiethoadon> chitiethoadons { get; set; }
    }
}
