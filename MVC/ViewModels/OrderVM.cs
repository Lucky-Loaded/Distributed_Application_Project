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

        public int Id_User { get; set; }

        public string Adress { get; set; }

        [Required]
        public DateTime Time_Order { get; set; }

        public float Delivery_Price { get; set; }

        public double Order_Price { get; set; }

        public OrderVM() { }
        public OrderVM(OrderDTO orderDTO) {
            Id = orderDTO.Id;
            Id_Film = orderDTO.Id_Film;
            Id_User = orderDTO.Id_User;
            Adress = orderDTO.Adress;
            Time_Order = orderDTO.Time_Order;
            Delivery_Price = orderDTO.Delivery_Price;
            Order_Price = orderDTO.Order_Price;
        }
    }
}