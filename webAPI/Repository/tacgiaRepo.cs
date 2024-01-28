using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webAPI.Data.Nguon;
using webAPI.Data.Sach;
using webAPI.DBContext;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Repository
{
    public class tacgiaRepo : tacgiaHandle
    {
        private readonly giaoTiepCSDL _context;
        private readonly IMapper _mapper;

        public tacgiaRepo(giaoTiepCSDL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTacGia(tacgiaModel model)
        {
            var newTacGia = _mapper.Map<tacgia>(model);
            _context.tacgias.Add(newTacGia);
            await _context.SaveChangesAsync();
            return newTacGia.Id;
        }

        public async Task DeleteTacGia(Guid id)
        {
            var existingTacGia = await _context.tacgias.FindAsync(id);

            if (existingTacGia != null)
            {
                _context.tacgias.Remove(existingTacGia);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Xu ly khi id null
            }
        }

        public async Task<List<tacgiaModel>> GetAllTacGia()
        {
            var tacgias = await _context.tacgias.ToListAsync();
            return _mapper.Map<List<tacgiaModel>>(tacgias);
        }

        public async Task<tacgiaModel> GetTacGiaById(Guid id)
        {
            var tacgias = await _context.tacgias.FindAsync(id);
            return _mapper.Map<tacgiaModel>(tacgias);
        }

        public async Task UpdateTacGia(Guid id, tacgiaModel model)
        {
                var existingTacGia = await _context.tacgias.SingleOrDefaultAsync(s => s.Id == id);

                if (existingTacGia != null)
                {
                    // Update existingTheLoai properties with values from model
                    _mapper.Map(model, existingTacGia);

                    _context.tacgias.Update(existingTacGia);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Xu ly khi id null
                }
        }
    }
}
