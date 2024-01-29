using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using System.Text;
using webAPI.Data.DangNhap;
using webAPI.DBContext;
using webAPI.Models;
using webAPI.Helpers;

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
                return BadRequest();

            var userModel = await _authContext.users.FirstOrDefaultAsync(x => x.Email == userObj.Email);
            if (userModel == null)
                return NotFound(new { Message = "User not found!" });

            if (!PasswordHasher.VerifyPassword(userObj.Pass, userModel.Pass))
                return BadRequest(new { Message = "Password is incorrect!" });

            // Sử dụng AutoMapper để ánh xạ từ UserModel sang User entity
            var mappedUser = _mapper.Map<User>(userModel);

            return Ok(new { Message = "Login Success!", User = mappedUser });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] userModel userObj)
        {
            if (userObj == null)
                return BadRequest();

            // Check existing email
            if (await checkEmailExistAsyn(userObj.Email))
                return BadRequest(new { Message = "Email already exists!" });

            // Check password strength
            var passwordStrengthMessage = checkPasswordStrength(userObj.Pass);
            if (!string.IsNullOrEmpty(passwordStrengthMessage))
                return BadRequest(new { Message = passwordStrengthMessage });

            // Hash the password before storing it in the database
            userObj.Pass = PasswordHasher.HashPassword(userObj.Pass);

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


        private Task<bool> checkEmailExistAsyn(string email)
        {
            return _authContext.users.AnyAsync(x => x.Email == email);
        }

        private string checkPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimun password should be 8!" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be Anphanumeric!");
            return sb.ToString();
        }
    }
}
