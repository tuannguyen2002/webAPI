using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    public class tacgiaModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên tác giả là bắt buộc")]
        [Display(Name = "Tên tác giả")]
        public string tentacgia { get; set; }

        [Required(ErrorMessage = "Quê quán là bắt buộc")]
        [Display(Name = "Quê quán")]
        public string quequan { get; set; }

        [Display(Name = "Ghi chú")]
        public string ghichu { get; set; }
    }
}
