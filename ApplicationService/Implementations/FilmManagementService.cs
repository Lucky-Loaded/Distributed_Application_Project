using Data.Context;
using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Repository.Implementations;

namespace ApplicationService.Implementations
{
    public class FilmManagementService
    {

        public List<FilmDTO> Get(string query) {
            List<FilmDTO> filmDto = new List<FilmDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (query == null)
                {
                    foreach (var item in unitOfWork.FilmRepository.Get())
                    {
                        filmDto.Add(new FilmDTO
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Publishment = item.Publishment,
                            Price = item.Price,
                            Sales = item.Sales,
                            Crew = item.Crew,
                            Comment = item.Comment

                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.FilmRepository.GetByQuery().Where(c => c.Title.Contains(query)).ToList())
                    {
                        filmDto.Add(new FilmDTO
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Publishment = item.Publishment,
                            Price = item.Price,
                            Sales = item.Sales,
                            Crew = item.Crew,
                            Comment = item.Comment
                        });
                    }
                }
            }
                return filmDto;
        }
        public bool Save(FilmDTO filmDTO)
        {
            Film film = new Film()
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
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (filmDTO.Id == 0)
                    {
                        unitOfWork.FilmRepository.Insert(film);
                    }
                    else
                    {
                        unitOfWork.FilmRepository.Update(film);
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
                    Film film = unitOfWork.FilmRepository.GetById(id);
                    unitOfWork.FilmRepository.Delete(film);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public FilmDTO GetById(int id)
        {
            FilmDTO filmDTO = new FilmDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Film film = unitOfWork.FilmRepository.GetById(id);

                filmDTO = new FilmDTO
                {
                    Id = film.Id,
                    Title = film.Title,
                    Publishment = film.Publishment,
                    Price = film.Price,
                    Sales = film.Sales,
                    Crew = film.Crew,
                    Comment = film.Comment
                };
            }
            return filmDTO;
        }

    }
}
