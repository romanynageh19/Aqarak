using AqarakCore.IdentityEnities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakRepository.Identity
{
    public class ApplicationUserSeeding
    {
        public static async Task UserSeeding(UserManager<AppUserIdentity> userManager)
        {
           
            if (!userManager.Users.Any())
            {
                var user = new AppUserIdentity
                {
                    UserName = "Test",
                    Email = "TEST@GMAIL.COM",
                    PhoneNumber = "012222565656"
                };

               await userManager.CreateAsync(user, "password");

                
            }
        }

    }
}
