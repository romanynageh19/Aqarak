using AqarakCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakCore.IRepository
{
    public interface IGenericRepoitory<T> where T:BaseEntity
    {
        Task<T> GetpropertyAsync(int id);
        Task<IEnumerable<T>> GetAllpropertyAsync();
        Task<IEnumerable<MyProperty>> SearchAsync(string query);

    }
}
