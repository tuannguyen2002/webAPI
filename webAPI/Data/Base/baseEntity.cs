using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Data.Base
{
    public class baseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedDate
        {
            get
            {
                return DateTime.Now.ToUniversalTime();
            }
            set { }
        }

        [Required]
        public DateTime UpdatedDate
        {
            get
            {
                return DateTime.Now.ToUniversalTime();
            }
            set { }
        }
    }
}
