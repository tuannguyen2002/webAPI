using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webAPI.Data.DangNhap;
using webAPI.DBContext;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly giaoTiepCSDL _authContext;
        private readonly IMapper _mapper;

        public UserController(giaoTiepCSDL appDbContext, IMapper mapper)
        {
            _authContext = appDbContext;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] userModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            var userModel = await _authContext.users.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Pass == userObj.Pass);
            if (userModel == null)
            {
                return NotFound(new { Message = "User not found!" });
            }

            // Sử dụng AutoMapper để ánh xạ từ UserModel sang User entity
            var mappedUser = _mapper.Map<User>(userModel);

            return Ok(new { Message = "Login Success!", User = mappedUser });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] userModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            // Sử dụng AutoMapper để ánh xạ từ User entity sang UserModel
            var Model = _mapper.Map<userModel>(userObj);

            // Ánh xạ từ UserModel sang User entity
            var userEntity = _mapper.Map<User>(Model);

            await _authContext.users.AddAsync(userEntity);
            await _authContext.SaveChangesAsync();

            // Trả về thông báo và User entity sau khi đăng ký
            var registeredUser = _mapper.Map<User>(Model);

            return Ok(new { Message = "User Registered!", User = registeredUser });
        }
    }
}
