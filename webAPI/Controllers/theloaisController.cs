using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.DBContext;
using webAPI.Models;
using webAPI.Data;
using NuGet.Protocol.Core.Types;
using webAPI.Data.HoaDon;
using webAPI.Data.Sach;
using webAPI.Handle;
using Microsoft.AspNetCore.Authorization;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class theloaisController : ControllerBase
    {
        private readonly theloaiHandle _theloai;

        public theloaisController(theloaiHandle theloai)
        {
            _theloai = theloai;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _theloai.GetAllTheLoai());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var theloai = await _theloai.GetTheLoaiById(id);
            return theloai == null ? NotFound() : Ok(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> Create(theloaiModel model)
        {
            var newTheLoaiId = await _theloai.CreateTheLoai(model);
            var theloai = await _theloai.GetTheLoaiById(newTheLoaiId);
            return Ok(theloai);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, theloaiModel model)
        {
            await _theloai.UpdateTheLoai(id, model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _theloai.DeleteTheLoai(id);
            return Ok();
        }
    }
}
