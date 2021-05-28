using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public byte Age { get; set; }

        public double Budget { get; set; }

        public int Buyed { get; set; } 

        public string Favorites { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
