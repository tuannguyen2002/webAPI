using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webAPI.Data;

namespace webAPI.Models
{
    public class sachModel
    {
        public Guid? Id { get; set; }

        [Required]
        public string tensach { get; set; }

        //Khóa ngoại bảng tacgia
        public Guid tacgiaID { get; set; }
        [ForeignKey("tacgiaID")]

        //khóa ngoại bảng nhaxuatban
        public Guid nhaxbID { get; set; }
        [ForeignKey("nhaxbID")]

        [Required]
        [Range(1000, int.MaxValue)]
        public int giaban { get; set; } = 0;

        [Required]
        [Range(1, int.MaxValue)]
        public int soluong { get; set; } = 0;

        public string ghichu { get; set; }
    }
}
