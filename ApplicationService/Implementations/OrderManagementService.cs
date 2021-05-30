using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrderManagementService
    {
       
            private Cinema7SystemDBContext ctx = new Cinema7SystemDBContext();

            

            public List<OrderDTO> Get()
            {
            List<OrderDTO> orderDTO = new List<OrderDTO>();

            foreach (var item in ctx.Orders.ToList())
            {
                orderDTO.Add(new OrderDTO
                {
                    Id = item.Id,
                    Id_Film = item.Film_Id,
                    /*Film = new FilmDTO
                    {
                        Id = item.Film_Id,
                        Title = item.Film.Title,
                        Publishment = item.Film.Publishment,
                        Price = item.Film.Price,
                        Sales = item.Film.Sales,
                        Crew = item.Film.Crew,
                        Comment = item.Film.Comment
                    },*/
                    Id_User = item.User_Id,
                    /*User = new UserDTO
                    {
                        Id = item.User_Id,
                        Name = item.User.Name,
                        Age = item.User.Age,
                        Budget = item.User.Budget,
                        Buyed = item.User.Buyed,
                        Favorites = item.User.Favorites,
                        Description = item.User.Description
                    },*/
                    Address = item.Address,
                    Time_Order = item.Time_Order,
                    Delivery_Price = item.Delivery_Price,
                    Order_Price = item.Order_Price
                });
            }
            return orderDTO;
            }
        public OrderDTO GetByID(int id) {
            Order item = ctx.Orders.Find(id);
            OrderDTO orderDTO = new OrderDTO
            {
                
                Order_Price = item.Order_Price,
                Id_Film = item.Film_Id,
                /*Film = new FilmDTO
                {
                    Id = item.Film_Id,
                    Title = item.Film.Title,
                    Publishment = item.Film.Publishment,
                    Price = item.Film.Price,
                    Sales = item.Film.Sales,
                    Crew = item.Film.Crew,
                    Comment = item.Film.Comment
                },*/
                Id_User = item.User_Id,
                /*User = new UserDTO
                {
                    Id = item.User_Id,
                    Name = item.User.Name,
                    Age = item.User.Age,
                    Budget = item.User.Budget,
                    Buyed = item.User.Buyed,
                    Favorites = item.User.Favorites,
                    Description = item.User.Description
                },*/
                Id = item.Id,
                Address = item.Address,
                Time_Order = item.Time_Order,
                Delivery_Price = item.Delivery_Price

            };
            return orderDTO;
        }

            public bool Save(OrderDTO orderDTO)
            {
            if (orderDTO.Id_Film == 0)
            {
                return false;
            }
            else if (orderDTO.Id_User == 0)
            {
                    return false;
                }
            


    

            Order order = new Order
            {
                Id = orderDTO.Id,
                Address = orderDTO.Address,
                Time_Order = orderDTO.Time_Order,
                Delivery_Price = orderDTO.Delivery_Price,
                Order_Price = orderDTO.Order_Price,
                    Film_Id = orderDTO.Id_Film,
                    User_Id = orderDTO.Id_User
                    
                };
                try
                {
                    ctx.Orders.Add(order);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public bool Delete(int id)
            {
                try
                {
                    Order order = ctx.Orders.Find(id);
                    ctx.Orders.Remove(order);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
