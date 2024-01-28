using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webAPI.Data.Nguon;
using webAPI.Data.Sach;
using webAPI.DBContext;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Repository
{
    public class sachRepo : sachHandle
    {
        private readonly giaoTiepCSDL _context;
        private readonly IMapper _mapper;

        public sachRepo(giaoTiepCSDL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateSach(sachModel model)
        {
            var newSach = _mapper.Map<sach>(model);
            newSach.Id = Guid.NewGuid();
            _context.saches.Add(newSach);
            await _context.SaveChangesAsync();
            return newSach.Id;
        }

        public async Task DeleteSach(Guid id)
        {
            var existingSach = await _context.saches.FindAsync(id);

            if (existingSach != null)
            {
                _context.saches.Remove(existingSach);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Xu ly khi id null
            }
        }

        public async Task<List<sachModel>> GetAllSach()
        {
            var saches = await _context.saches.ToListAsync();
            return _mapper.Map<List<sachModel>>(saches);
        }

        public async Task<sachModel> GetSachById(Guid id)
        {
            var saches = await _context.saches.FindAsync(id);
            return _mapper.Map<sachModel>(saches);
        }

        public async Task UpdateSach(Guid id, sachModel model)
        {
            var existingSach = await _context.saches.SingleOrDefaultAsync(s => s.Id == id);

            if (existingSach != null)
            {
                // Update existingTheLoai properties with values from model
                _mapper.Map(model, existingSach);

                _context.saches.Update(existingSach);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Xu ly khi id null
            }
        }
    }
}
