using Data.Context;
using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;



namespace ApplicationService.Implementations
{
    public class FilmManagementService
    {
        private CinemaSystemDBContext ctx = new CinemaSystemDBContext();

        public List<FilmDTO> Get() {
            List<FilmDTO> filmDto = new List<FilmDTO>();

            foreach (var item in ctx.Films.ToList()) {
                filmDto.Add(new FilmDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Publishment = item.Publishment,
                    Price = item.Price
                });
            }
            return filmDto;
        }
        public bool Save(FilmDTO filmDTO) {
            Film Film = new Film
            {
                Title = filmDTO.Title,
                Publishment = filmDTO.Publishment,
                Price = filmDTO.Price
            };
            try
            {
                ctx.Films.Add(Film);
                ctx.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Film film = ctx.Films.Find(id);
                ctx.Films.Remove(film);
                ctx.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
