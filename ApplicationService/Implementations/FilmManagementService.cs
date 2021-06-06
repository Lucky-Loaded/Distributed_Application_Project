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
        private Cinema7SystemDBContext ctx = new Cinema7SystemDBContext();

        public List<FilmDTO> Get() {
            List<FilmDTO> filmDto = new List<FilmDTO>();

            foreach (var item in ctx.Films.ToList()) {
                filmDto.Add(new FilmDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Publishment = item.Publishment,
                    Price = item.Price,
                    Sales = item.Sales,
                    Crew = item.Crew,
                    Comment = item.Comment

                }) ;
            }
            return filmDto;
        }
        public bool Save(FilmDTO filmDTO) {
            Film Film = new Film
            {
                Title = filmDTO.Title,
                Publishment = filmDTO.Publishment,
                Price = filmDTO.Price,
                Sales = filmDTO.Sales,
                Crew = filmDTO.Crew,
                Comment = filmDTO.Comment

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
        public bool Update(FilmDTO filmDTO)
        {
            Film Film = new Film
            {
               Id = filmDTO.Id,
                Title = filmDTO.Title,
                Publishment = filmDTO.Publishment,
                Price = filmDTO.Price,
                Sales = filmDTO.Sales,
                Crew = filmDTO.Crew,
                Comment = filmDTO.Comment

            };
            try
            {
                
                ctx.Films.Remove(ctx.Films.Find(filmDTO.Id));
                ctx.Films.Add(Film);
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
                Film film = ctx.Films.Find(id);
                ctx.Films.Remove(film);
                ctx.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public FilmDTO GetByID(int id) {

            FilmDTO filmDTO = new FilmDTO();

            Film film = ctx.Films.Find(id);
            if (film != null) {
                filmDTO.Id = film.Id;
                filmDTO.Title = film.Title;
                filmDTO.Publishment = film.Publishment;
                filmDTO.Price = film.Price;
                filmDTO.Sales = film.Sales;
                filmDTO.Crew = film.Crew;
                filmDTO.Comment = film.Comment;
            }
            return filmDTO;
        }
        /*public FilmDTO Edit(int id) {
            FilmDTO filmDTO = new FilmDTO();

            Film film = ctx.Films.Find(id){
            
            }

            
        }*/
        
    }
}
