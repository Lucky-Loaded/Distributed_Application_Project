using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte Age { get; set; }

        public double Budget { get; set; }

        public int Phone { get; set; }

        public string Favorites { get; set; }

        public string Description { get; set; }
    }
}
