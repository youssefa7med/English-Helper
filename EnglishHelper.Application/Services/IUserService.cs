using EnglishHelper.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishHelper.Application.Services
{
    public interface IUserService
    {
        Task<UserDTO> RegisterAsync(RegisterDTO model);
        Task<UserDTO> LoginAsync(LoginDTO model);
    }
}
