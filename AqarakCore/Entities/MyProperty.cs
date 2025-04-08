using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakCore.Entities
{
    public class MyProperty:BaseEntity
    {

        public string Address { get; set; }
        public string City { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public string PropertyType { get; set; }
        public string  Description { get; set; }
        public int LocationId { get; set; }
        public string PhotoUrl { get; set; }
        public int OwnerId { get; set; }
      
        public User User { get; set; }
    }
}
