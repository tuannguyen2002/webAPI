using webAPI.Data.Base;
using webAPI.Data.Sach;

namespace webAPI.Data.Nguon
{
    public class nhaxb : baseEntity
    {
        public string tennhaxb { get; set; }

        public string sdt { get; set; }

        public string ghichu { get; set; }

        public ICollection<sach> saches { get; set; }
    }
}
