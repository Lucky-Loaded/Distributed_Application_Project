using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class FilmVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? Publishment { get; set; }

        public double Price { get; set; }

        public int Sales { get; set; }

        public string Crew { get; set; }
        public string Comment { get; set; }

        public FilmVM() { }

        public FilmVM(FilmDTO filmDTO) {
            Id = filmDTO.Id;
            Title = filmDTO.Title;
            Publishment = filmDTO.Publishment;
            Price = filmDTO.Price;
            Sales = filmDTO.Sales;
            Crew = filmDTO.Crew;
            Comment = filmDTO.Comment;
        }
    }
}