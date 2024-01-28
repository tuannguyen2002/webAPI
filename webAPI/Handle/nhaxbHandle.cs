using webAPI.Models;

namespace webAPI.Handle
{
    public interface nhaxbHandle
    {
        public Task<List<nhaxbModel>> GetAllNhaXB();
        public Task<nhaxbModel> GetNhaXBById(Guid id);
        public Task<Guid> CreateNhaXB(nhaxbModel model);
        public Task UpdateNhaXB(Guid id, nhaxbModel model);
        public Task DeleteNhaXB(Guid id);
    }
}
