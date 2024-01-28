using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webAPI.Data;

namespace webAPI.Models
{
    public class chitiethdModel
    {
        public Guid Id { get; set; }

        [Required]
        public int hoadonID { get; set; }
        [ForeignKey("hoadonID")]

        //Khóa ngoại bảng sach
        public int sachID { get; set; }
        [ForeignKey("sachID")]

        [Required]
        [Range(1, int.MaxValue)]
        public int soluong { get; set; } = 0;

        [Required]
        [Range(1000, int.MaxValue)]
        public int giaban { get; set; } = 0;

        public string ghichu { get; set; }
    }
}
