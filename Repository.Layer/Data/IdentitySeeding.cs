using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Layer.Data.Identity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Data
{
    public static class IdentitySeeding
    {
        public async static Task SeedAsync(UserManager<Users> userManager)
        {
            var user = new Users()
            {
                DisplayName = "madonna",
                Email = "madonnamossad86@gmail.com",
                UserName="madonnamosaad86",
                PhoneNumber = "087654311"
            };
            if (userManager.Users.Count() == 0)
            {
                await userManager.CreateAsync(user, "Password000#");
            }
        }
    }
}
