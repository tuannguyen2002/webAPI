using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sachesController : ControllerBase
    {
        private readonly sachHandle _sach;

        public sachesController(sachHandle sach)
        {
            _sach = sach;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _sach.GetAllSach());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sach = await _sach.GetSachById(id);
            return sach == null ? NotFound() : Ok(sach);
        }

        [HttpPost]
        public async Task<IActionResult> Create(sachModel model)
        {
            var newSach = await _sach.CreateSach(model);
            var sach = await _sach.GetSachById(newSach);
            return Ok(sach);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, sachModel model)
        {
            await _sach.UpdateSach(id, model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sach.DeleteSach(id);
            return Ok();
        }
    }
}
