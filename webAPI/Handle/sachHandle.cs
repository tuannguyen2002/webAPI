using webAPI.Models;

namespace webAPI.Handle
{
    public interface sachHandle
    {
        public Task<List<sachModel>> GetAllSach();
        public Task<sachModel> GetSachById(Guid id);
        public Task<Guid> CreateSach(sachModel model);
        public Task UpdateSach(Guid id, sachModel model);
        public Task DeleteSach(Guid id);
    }
}
