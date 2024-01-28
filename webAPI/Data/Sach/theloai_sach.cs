using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webAPI.Data.Base;

namespace webAPI.Data.Sach
{
    public class theloai_sach : baseEntity
    {
        //Khóa ngoại bảng sach
        public Guid sachID { get; set; }
        public sach sach { get; set; }


        //Khóa ngoại bảng theloai
        public Guid theloaiID { get; set; }
        public theloai theloai { get; set; }
    }
}
