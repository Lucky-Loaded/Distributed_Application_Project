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
    public class UserManagementService
    {

        List<UserDTO> userDto = new List<UserDTO>();

        public List<UserDTO> Get(string query)
        {
            List<UserDTO> userDto = new List<UserDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (query == null)
                {
                    foreach (var item in unitOfWork.UserRepository.Get())
                    {
                        userDto.Add(new UserDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Age = item.Age,
                            Budget = item.Budget,
                            Phone = item.Buyed,
                            Favorites = item.Favorites,
                            Description = item.Description
                        });

                    }
                }
                else
                {
                    foreach (var item in unitOfWork.UserRepository.GetByQuery().Where(c => c.Name.Contains(query)).ToList())
                    {
                        userDto.Add(new UserDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Age = item.Age,
                            Budget = item.Budget,
                            Phone = item.Buyed,
                            Favorites = item.Favorites,
                            Description = item.Description
                        });
                    }
                }
               
            }
            return userDto;
        }
        public bool Save(UserDTO userDTO)
        {
            User User = new User()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Age = userDTO.Age,
                Budget = userDTO.Budget,
                Buyed = userDTO.Phone,
                Favorites = userDTO.Favorites,
                Description = userDTO.Description
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (userDTO.Id == 0)
                    {
                        unitOfWork.UserRepository.Insert(User);
                    }
                    else
                    {
                        unitOfWork.UserRepository.Update(User);
                    }

                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                System.Console.WriteLine(User);
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    User user = unitOfWork.UserRepository.GetById(id);
                    unitOfWork.UserRepository.Delete(user);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public UserDTO GetByID(int id)
        {

            UserDTO userDTO = new UserDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetById(id);
                if (user != null)
                {
                    userDTO = new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Age = user.Age,
                        Budget = user.Budget,
                        Phone = user.Buyed,
                        Favorites = user.Favorites,
                        Description = user.Description

                    };
                }
            }
            return userDTO;
        }

    }
}
