using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        
        

        public string Adress { get; set; }

        
        public DateTime? TimeOrder { get; set; }

        public float DeliveryPrice { get; set; }

        public decimal OrderPrice { get; set; }
        public int FilmId { get; set; }


        public int UserId { get; set; }
        public FilmVM FilmVM { get; set; }

        public UserVM UserVM { get; set; }

        public OrderVM() { }
        public OrderVM(OrderDTO orderDTO) {
            Id = orderDTO.Id;
                        FilmId = orderDTO.Film.Id;
            FilmVM = new FilmVM
            {
                Id = orderDTO.Film.Id,
                Title = orderDTO.Film.Title,
                Publishment = orderDTO.Film.Publishment,
                Price = orderDTO.Film.Price,
                Sales = orderDTO.Film.Sales,
                Crew = orderDTO.Film.Crew,
                Comment = orderDTO.Film.Comment
            };
                         UserId = orderDTO.User.Id;
            UserVM = new UserVM
                        {
                            Id = orderDTO.User.Id,
                            Name = orderDTO.User.Name,
                            Age = orderDTO.User.Age,
                            Budget = orderDTO.User.Budget,
                            Buyed = orderDTO.User.Phone,
                            Favorites = orderDTO.User.Favorites,
                            Description = orderDTO.User.Description
                        };
            Adress = orderDTO.Address;
                        TimeOrder = orderDTO.TimeOrder;
                        DeliveryPrice = orderDTO.DeliveryPrice;
                        OrderPrice = orderDTO.OrderPrice;
        }
    }
}