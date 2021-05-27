using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Film : BaseEntity
    {
        public string Title { get; set; }

        public DateTime Publishment { get; set; }

        public double Price { get; set; }


    }
}
