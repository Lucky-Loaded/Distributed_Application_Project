using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private FilmManagementService filmService = new FilmManagementService();

        public List<FilmDTO> GetFilms(string query)
        {
            return filmService.Get(query);
        }

        public string PostFilm(FilmDTO filmDto)
        {
            if (!filmService.Save(filmDto)){
                return "Film's not saved";
            }
            else {
                return "Film's saved";
            }
        }
        
        public string DeleteFilm(int id)
        {
            if (!filmService.Delete(id))
            {
                return "User's not deleted";
            }
            else 
            {
                return "User's deleted";
            }
        }
        public FilmDTO GetFilmByID(int id) {
            return filmService.GetById(id);
        }
        private UserManagementService userService = new UserManagementService();

        public List<UserDTO> GetUsers(string query)
        {
            return userService.Get(query);
        }

        public string PostUser(UserDTO userDto)
        {
            if (!userService.Save(userDto))
            {
                return "User's not saved";
            }
            else
            {
                return "User's saved";
            }
        }
        public string DeleteUser(int id)
        {
            if (!userService.Delete(id))
            {
                return "User's not deleted";
            }
            else
            {
                return "User's deleted";
            }
        }
        public UserDTO GetUserByID(int id)
        {
            return userService.GetByID(id);
        }
        private OrderManagementService orderService = new OrderManagementService();

        public List<OrderDTO> GetOrders(string query)
        {
            return orderService.Get(query);
        }

        public string PostOrder(OrderDTO orderDto)
        {
            if (!orderService.Save(orderDto))
            {
                return "Order's not saved";
            }
            else
            {
                return "Order's saved";
            }
        }
        public string DeleteOrder(int id)
        {
            if (!orderService.Delete(id))
            {
                return "Order's not deleted";
            }
            else
            {
                return "Order's deleted";
            }
        }
        public OrderDTO GetOrderByID(int id)
        {
            return orderService.GetById(id);
        }

    }
}
