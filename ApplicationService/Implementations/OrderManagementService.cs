using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrderManagementService
    {

            public List<OrderDTO> Get(string query)
            {
            List<OrderDTO> orderDTO = new List<OrderDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (query == null)
                {
                    foreach (var item in unitOfWork.OrderRepository.Get())
                    {
                        orderDTO.Add(new OrderDTO
                        {
                            Id = item.Id,
                            Film = new FilmDTO
                            {
                                Id = item.Film.Id,
                                Title = item.Film.Title,
                                Publishment = item.Film.Publishment,
                                Price = item.Film.Price,
                                Sales = item.Film.Sales,
                                Crew = item.Film.Crew,
                                Comment = item.Film.Comment
                            },
                            User = new UserDTO
                            {
                                Id = item.User.Id,
                                Name = item.User.Name,
                                Age = item.User.Age,
                                Budget = item.User.Budget,
                                Phone = item.User.Buyed,
                                Favorites = item.User.Favorites,
                                Description = item.User.Description
                            },
                            Address = item.Address,
                            TimeOrder = item.TimeOrder,
                            DeliveryPrice = item.DeliveryPrice,
                            OrderPrice = item.OrderPrice
                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.OrderRepository.GetByQuery().Where(c => c.User.Name.Contains(query)).ToList())
                    {
                        orderDTO.Add(new OrderDTO
                        {
                            Id = item.Id,
                            Film = new FilmDTO
                            {
                                Id = item.FilmId,
                                Title = item.Film.Title,
                                Publishment = item.Film.Publishment,
                                Price = item.Film.Price,
                                Sales = item.Film.Sales,
                                Crew = item.Film.Crew,
                                Comment = item.Film.Comment
                            },
                            User = new UserDTO
                            {
                                Id = item.UserId,
                                Name = item.User.Name,
                                Age = item.User.Age,
                                Budget = item.User.Budget,
                                Phone = item.User.Buyed,
                                Favorites = item.User.Favorites,
                                Description = item.User.Description
                            },
                            Address = item.Address,
                            TimeOrder = item.TimeOrder,
                            DeliveryPrice = item.DeliveryPrice,
                            OrderPrice = item.OrderPrice
                        });
                    }
                }
            }
                return orderDTO;
            }
        public OrderDTO GetById(int id)
        {
            OrderDTO orderDTO = new OrderDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Order item = unitOfWork.OrderRepository.GetById(id);
                if (item != null)
                {
                    orderDTO = new OrderDTO
                    {
                        Id = item.Id,
                        Address = item.Address,
                        OrderPrice = item.OrderPrice,
                        DeliveryPrice = item.DeliveryPrice,
                        TimeOrder = item.TimeOrder,
                        Film = new FilmDTO
                        {
                            Id = item.FilmId,
                            Title = item.Film.Title,
                            Crew = item.Film.Crew,
                            Publishment = item.Film.Publishment,
                            Sales = item.Film.Sales,

                            Price = item.Film.Price,
                            Comment = item.Film.Comment
                        },

                        User = new UserDTO
                        {
                            Id = item.UserId,
                            Name = item.User.Name,
                            Age = item.User.Age,
                            Budget = item.User.Budget,
                            Phone = item.User.Phone,
                            Favorites = item.User.Favorites,
                            Description = item.User.Description
                        }

                    };
                }
            }
                return orderDTO;
            }
        

        public bool Save(OrderDTO orderDTO)
            {
            
            Order order = new Order
            {
                Id = orderDTO.Id,
                Address = orderDTO.Address,
                TimeOrder = orderDTO.TimeOrder,
                DeliveryPrice = orderDTO.DeliveryPrice,
                OrderPrice = orderDTO.OrderPrice,
                    FilmId = orderDTO.Film.Id,
                    UserId = orderDTO.User.Id
                    
                };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (orderDTO.Id == 0)
                    {
                        unitOfWork.OrderRepository.Insert(order);
                    }
                    else
                    {
                        unitOfWork.OrderRepository.Update(order);
                    }
                    unitOfWork.Save();
                }

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
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Order order = unitOfWork.OrderRepository.GetById(id);
                    unitOfWork.OrderRepository.Delete(order);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        }
    }
