using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        

        
        
        public string Address { get; set; }

        
        public DateTime? TimeOrder { get; set; }

        public float DeliveryPrice { get; set; }

        public decimal OrderPrice { get; set; }
        public FilmDTO Film { get; set; }


        public UserDTO User { get; set; }

    }
}
