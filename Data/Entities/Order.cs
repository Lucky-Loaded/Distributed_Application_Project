using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {

        public string Address { get; set; }

        [Required]
        public DateTime? TimeOrder { get; set; }
        public float DeliveryPrice { get; set; }
        public decimal OrderPrice { get; set; }


        public int FilmId { get; set; }
        public virtual Film Film { get; set; }

        public int UserId { get; set; }
        public virtual User User{ get; set; }
    }
}
