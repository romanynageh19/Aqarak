using AqarakCore.IdentityEnities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakCore.Iservice
{
    public interface  ICreateToken
    {
        Task< string >CreateTokenAsync( AppUserIdentity user , UserManager<AppUserIdentity> manager);
    }
}
