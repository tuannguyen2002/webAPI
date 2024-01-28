using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class hoadonModel
    {
        public Guid hoadonId { get; set; }

        //Khóa ngoại bảng dangnhap
        [Required]
        public int userID { get; set; }
        [ForeignKey("UserId")]

        [Required]
        public DateTime thoigianban { get; set; }

        [Required]
        [Range(1000, int.MaxValue)]
        public int tongtien { get; set; } = 0;

        public string ghichu { get; set; }
    }
}
