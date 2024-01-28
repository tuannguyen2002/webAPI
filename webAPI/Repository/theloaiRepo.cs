using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webAPI.Data.Sach;
using webAPI.DBContext;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Repository
{
    public class theloaiRepo : theloaiHandle
    {
        private readonly giaoTiepCSDL _context;
        private readonly IMapper _mapper;

        public theloaiRepo(giaoTiepCSDL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<theloaiModel>> GetAllTheLoai()
        {
            var theloais = await _context.theloais.ToListAsync();
            return _mapper.Map<List<theloaiModel>>(theloais);
        }

        public async Task<theloaiModel> GetTheLoaiById(Guid id)
        {
            var theloais = await _context.theloais.FindAsync(id);
            return _mapper.Map<theloaiModel>(theloais);
        }

        public async Task<Guid> CreateTheLoai(theloaiModel model)
        {
            var newTheLoai = _mapper.Map<theloai>(model);
            _context.theloais.Add(newTheLoai);
            await _context.SaveChangesAsync();
            return newTheLoai.Id;
        }

        public async Task UpdateTheLoai(Guid id, theloaiModel model)
        {
                var existingTheLoai = await _context.theloais.SingleOrDefaultAsync(s => s.Id == id);

                if (existingTheLoai != null)
                {
                    // Update existingTheLoai properties with values from model
                    _mapper.Map(model, existingTheLoai);

                    _context.theloais.Update(existingTheLoai);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Xu ly khi id null
                }
        }

        public async Task DeleteTheLoai(Guid id)
        {
            var existingTheLoai = await _context.theloais.FindAsync(id);

            if (existingTheLoai != null)
            {
                _context.theloais.Remove(existingTheLoai);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Xu ly khi id null
            }
        }
    }
}
