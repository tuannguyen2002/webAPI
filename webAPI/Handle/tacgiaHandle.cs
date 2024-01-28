using webAPI.Models;

namespace webAPI.Handle
{
    public interface tacgiaHandle
    {
        public Task<List<tacgiaModel>> GetAllTacGia();
        public Task<tacgiaModel> GetTacGiaById(Guid id);
        public Task<Guid> CreateTacGia(tacgiaModel model);
        public Task UpdateTacGia(Guid id, tacgiaModel model);
        public Task DeleteTacGia(Guid id);
    }
}
