using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.ServiceInterfaces
{
    public interface IAuthService
    {
        public Task<string> CreateTokenAsync(Users user , UserManager<Users> userManager);
    }
}
