using AutoMapper;
using webAPI.Data.DangNhap;
using webAPI.Data.HoaDon;
using webAPI.Data.Nguon;
using webAPI.Data.Sach;
using webAPI.Models; // Import namespace của models

namespace webAPI.Mapper
{
    public class map : Profile
    {
        public map() 
        {
            CreateMap<theloaiModel, theloai>().ReverseMap();
            CreateMap<tacgiaModel, tacgia>().ReverseMap();
            CreateMap<sachModel, sach>().ReverseMap();
            CreateMap<nhaxbModel, nhaxb>().ReverseMap();
            CreateMap<hoadonModel, hoadon>().ReverseMap();
            CreateMap<chitiethdModel, chitiethoadon>().ReverseMap();
            CreateMap<userModel, User>().ReverseMap();
        }
    }
}
