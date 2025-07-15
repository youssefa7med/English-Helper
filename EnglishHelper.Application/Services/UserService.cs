using EnglishHelper.Application.DTOs;
using EnglishHelper.Data;
using EnglishHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EnglishHelper.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO model)
        {
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
                throw new Exception("Email already exists");

            var user = new User
            {
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = HashPassword(model.Password),
                Level = 1,
                TotalPoints = 0
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Level = user.Level,
                TotalPoints = user.TotalPoints,
                Token = "dummy-token" // هنعمل التوكن بعدين
            };
        }

        public async Task<UserDTO> LoginAsync(LoginDTO model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || !VerifyPassword(model.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            return new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Level = user.Level,
                TotalPoints = user.TotalPoints,
                Token = "dummy-token" // هنعمل التوكن بعدين
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}