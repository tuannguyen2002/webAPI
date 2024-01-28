using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    public class theloaiModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên thể loại")]
        [Required(ErrorMessage = "Tên thể loại là bắt buộc!")]
        public string tentheloai { get; set; }

        [Display(Name = "Ghi chú")]
        public string ghichu { get; set; }
    }
}
