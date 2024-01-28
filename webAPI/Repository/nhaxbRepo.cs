using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webAPI.Data.Nguon;
using webAPI.DBContext;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Repository
{
    public class nhaxbRepo : nhaxbHandle
    {
        private readonly giaoTiepCSDL _context;
        private readonly IMapper _mapper;

        public nhaxbRepo(giaoTiepCSDL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateNhaXB(nhaxbModel model)
        {
            var newNXB = _mapper.Map<nhaxb>(model);
            _context.nhaxuatbans.Add(newNXB);
            await _context.SaveChangesAsync();  
            return newNXB.Id;
        }

        public async Task DeleteNhaXB(Guid id)
        {
            var existingNXB = await _context.nhaxuatbans.FindAsync(id);

            if (existingNXB != null)
            {
                _context.nhaxuatbans.Remove(existingNXB);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Xu ly khi id null
            }
        }

        public async Task<List<nhaxbModel>> GetAllNhaXB()
        {
            var nxbs = await _context.nhaxuatbans.ToListAsync();
            return _mapper.Map<List<nhaxbModel>>(nxbs);
        }

        public async Task<nhaxbModel> GetNhaXBById(Guid id)
        {
            var nxbs = await _context.nhaxuatbans.FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<nhaxbModel>(nxbs);
        }

        public async Task UpdateNhaXB(Guid id, nhaxbModel model)
        {
             var existingNXB = await _context.nhaxuatbans.FindAsync(id);

             if (existingNXB != null)
             {
                // Update existingTheLoai properties with values from model
                _mapper.Map(model, existingNXB);

                _context.nhaxuatbans.Update(existingNXB);
                await _context.SaveChangesAsync();
             }
             else
             {
                 //Xu ly khi id null
             }
        }
    }
}
