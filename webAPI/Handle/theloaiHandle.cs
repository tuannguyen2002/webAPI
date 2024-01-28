using Microsoft.EntityFrameworkCore;
using webAPI.DBContext;
using webAPI.Models;

namespace webAPI.Handle
{
    public interface theloaiHandle
    {
        public Task<List<theloaiModel>> GetAllTheLoai();
        public Task<theloaiModel> GetTheLoaiById(Guid id);
        public Task<Guid> CreateTheLoai(theloaiModel model);
        public Task UpdateTheLoai(Guid id, theloaiModel model);
        public Task DeleteTheLoai(Guid id);
    }
}
