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

        public int Id_Film { get; set; }
        public virtual FilmDTO Film { get; set; }

        public int Id_User { get; set; }
        public virtual UserDTO User { get; set; }

        public string Adress { get; set; }

        
        public DateTime Time_Order { get; set; }

        public float Delivery_Price { get; set; }

        public double Order_Price { get; set; }

        public FilmVM FilmVM { get; set; }

        public UserVM UserVM { get; set; }

        public OrderVM() { }
        public OrderVM(OrderDTO orderDTO) {
            Id = orderDTO.Id;
                        Id_Film = orderDTO.Id_Film;
                        /*Film = new FilmDTO
                        {
                            Id = orderDTO.Id_Film,
                            Title = orderDTO.Film.Title,
                            Publishment = orderDTO.Film.Publishment,
                            Price = orderDTO.Film.Price,
                            Sales = orderDTO.Film.Sales,
                            Crew = orderDTO.Film.Crew,
                            Comment = orderDTO.Film.Comment
                        }; */
                         Id_User = orderDTO.Id_User;
            /* User = new UserDTO
                        {
                            Id = orderDTO.Id_User,
                            Name = orderDTO.User.Name,
                            Age = orderDTO.User.Age,
                            Budget = orderDTO.User.Budget,
                            Buyed = orderDTO.User.Buyed,
                            Favorites = orderDTO.User.Favorites,
                            Description = orderDTO.User.Description
                        };*/
            Adress = orderDTO.Address;
                        Time_Order = orderDTO.Time_Order;
                        Delivery_Price = orderDTO.Delivery_Price;
                        Order_Price = orderDTO.Order_Price;
        }
    }
}