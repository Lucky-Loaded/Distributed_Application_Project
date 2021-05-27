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
    public class UserManagementService
    {
        private CinemaSystemDBContext ctx = new CinemaSystemDBContext();

        List<UserDTO> userDto = new List<UserDTO>();

        public List<UserDTO> Get() {
            List<UserDTO> userDto = new List<UserDTO>();

            foreach (var item in ctx.Users.ToList()) {
                userDto.Add(new UserDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Budget = item.Budget,
                    Buyed = item.Buyed,
                    Favorites = item.Favorites,
                    Description = item.Description
                });

            }
            return userDto;
        }

        public bool Save(UserDTO userDTO)
        {
            User User = new User
            {
                Name = userDTO.Name,
                Age = userDTO.Age,
                Budget = userDTO.Budget,
                Buyed = userDTO.Buyed,
                Favorites = userDTO.Favorites,
                Description = userDTO.Description
            };
            try
            {
                ctx.Users.Add(User);
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
                User user = ctx.Users.Find(id);
                ctx.Users.Remove(user);
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
