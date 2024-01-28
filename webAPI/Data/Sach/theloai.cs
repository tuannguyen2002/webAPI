using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webAPI.Data.Base;

namespace webAPI.Data.Sach
{
    public class theloai : baseEntity
    {
        public string tentheloai { get; set; }

        public string ghichu { get; set; }

        public ICollection<theloai_sach> theloai_Saches { get; set; }
    }
}
