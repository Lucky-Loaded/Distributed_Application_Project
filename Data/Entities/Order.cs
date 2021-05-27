using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {

        public int Id_Film { get; set; }

        public int Id_User { get; set; }

        public string Adress { get; set; }

        public DateTime Time_Order { get; set; }

        public float Delivery_Price { get; set; }

        public double Order_Price { get; set; }
    }
}
