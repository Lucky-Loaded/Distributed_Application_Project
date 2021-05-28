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
       
            private Cinema1SystemDBContext ctx = new Cinema1SystemDBContext();

            List<OrderDTO> orderDto = new List<OrderDTO>();

            public List<OrderDTO> Get()
            {
                List<OrderDTO> orderDto = new List<OrderDTO>();

                foreach (var item in ctx.Orders.ToList())
                {
                orderDto.Add(new OrderDTO
                    {
                        Id = item.Id,
                        Id_Film = item.Id_Film,
                        Id_User = item.Id_User,
                        Adress = item.Adress,
                        Time_Order = item.Time_Order,
                        Delivery_Price = item.Delivery_Price,
                        Order_Price = item.Order_Price
                        
                    });

                }
                return orderDto;
            }

            public bool Save(OrderDTO orderDTO)
            {
                Order Order = new Order
                {
                    Id_Film = orderDTO.Id_Film,
                    Id_User = orderDTO.Id_User,
                    Adress = orderDTO.Adress,
                    Time_Order = orderDTO.Time_Order,
                    Delivery_Price = orderDTO.Delivery_Price,
                    Order_Price = orderDTO.Order_Price
                };
                try
                {
                    ctx.Orders.Add(Order);
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
