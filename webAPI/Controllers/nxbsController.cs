using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Handle;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nxbsController : ControllerBase
    {
        private readonly nhaxbHandle _nxb;

        public nxbsController(nhaxbHandle nxb)
        {
            _nxb = nxb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _nxb.GetAllNhaXB());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var nxb = await _nxb.GetNhaXBById(id);
            return nxb == null ? NotFound() : Ok(nxb);
        }

        [HttpPost]
        public async Task<IActionResult> Create(nhaxbModel model)
        {
            var newNXB = await _nxb.CreateNhaXB(model);
            var nxb = await _nxb.GetNhaXBById(newNXB);
            return Ok(nxb);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, nhaxbModel model)
        {
            await _nxb.UpdateNhaXB(id, model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
             await _nxb.DeleteNhaXB(id);
            return Ok();
        }
    }
}
