using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakCore.IdentityEnities
{
    public class AppUserIdentity:IdentityUser
    {
        public string DisplayName { get; set; } = null!;
    }
}
