using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakCore.Entities
{
    public class MyProperty:BaseEntity
    {

        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public int Size { get; set; }
        public int Price { get; set; }
        public string PropertyType { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int LocationId { get; set; }
        public string PhotoUrl { get; set; } = null!;
        public int OwnerId { get; set; }

        public User User { get; set; } = null!;
    }
}
