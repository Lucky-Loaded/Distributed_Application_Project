using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte Age { get; set; }

        public double Budget { get; set; }

        public int Buyed { get; set; }

        public string Favorites { get; set; }

        public string Description { get; set; }

        public UserVM() { }

        public UserVM(UserDTO userDTO) {
            Id = userDTO.Id;
            Name = userDTO.Name;
            Age = userDTO.Age;
            Budget = userDTO.Budget;
            Buyed = userDTO.Phone;
            Favorites = userDTO.Favorites;
            Description = userDTO.Description;
                }
    }
}