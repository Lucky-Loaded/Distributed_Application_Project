using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
     public class FilmDTO
    
    {
        public int Id { get; set; }
        public string Title { get; set; }

    public DateTime Publishment { get; set; }

    public double Price { get; set; }

    public int Sales { get; set; }

    public string Crew { get; set; }
    public string Comment { get; set; }
}
}
