using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Talabat.API.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<Users> FindUserWithAddressAsync(this UserManager<Users> userManager,ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            var user = userManager.Users.Include(u=>u.Address).FirstOrDefault(u=>u.Email==email);
            return user;
        }
    }
}
