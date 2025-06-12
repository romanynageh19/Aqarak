using AqarakCore.IdentityEnities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakRepository.Data
{
    public class APPUserIdentityDbcontext:IdentityDbContext<AppUserIdentity>
    {
        public APPUserIdentityDbcontext(DbContextOptions<APPUserIdentityDbcontext>options):base(options)
        {
            
        }
    }
}
