using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tacgiasController : ControllerBase
    {
        private readonly tacgiaHandle _tacgia;

        public tacgiasController(tacgiaHandle tacgia)
        {
            _tacgia = tacgia;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _tacgia.GetAllTacGia());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tacgia = await _tacgia.GetTacGiaById(id);
            return tacgia == null ? NotFound() : Ok(tacgia);
        }

        [HttpPost]
        public async Task<IActionResult> Create(tacgiaModel model)
        {
            var newTacGiaId = await _tacgia.CreateTacGia(model);
            var tacgia = await _tacgia.GetTacGiaById(newTacGiaId);
            return Ok(tacgia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, tacgiaModel model)
        {
            await _tacgia.UpdateTacGia(id, model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tacgia.DeleteTacGia(id);
            return Ok();
        }
    }
}
