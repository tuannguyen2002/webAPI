using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webAPI.Data.Sach;
using webAPI.Data.Base;

namespace webAPI.Data.Nguon
{
    public class tacgia : baseEntity
    {
        public string tentacgia { get; set; }

        public string quequan { get; set; }

        public string ghichu { get; set; }

        public ICollection<sach> saches { get; set; }
    }
}
