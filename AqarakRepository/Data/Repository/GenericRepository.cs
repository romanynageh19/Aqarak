using AqarakCore.Entities;
using AqarakCore.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakRepository.Data.Repository
{
    public class GenericRepository<T> : IGenericRepoitory<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        

        public async Task<IEnumerable<T>> GetAllpropertyAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        

        public async Task<T> GetpropertyAsync(int id)
        {
            return await _dbcontext.Set<T>().FirstAsync(x=>x.Id==id);
        }
    }
}
