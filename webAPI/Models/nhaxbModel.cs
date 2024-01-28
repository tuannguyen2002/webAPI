using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    public class nhaxbModel
    {
        /*[Key]
        [Display(Name = "Mã nhà xuất bản")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public Guid Id { get; set; }

        [Display(Name = "Tên nhà xuất bản")]
        [Required(ErrorMessage = "Tên NXB là bắt buộc")]
        public string tennhaxb { get; set; }

        [Display(Name = "SĐT nhà xuất bản")]
        [Required(ErrorMessage = "SĐT NXB là bắt buộc")]
        public string sdt { get; set; }

        [Display(Name = "Ghi chú")]
        public string ghichu { get; set; }
    }
}
