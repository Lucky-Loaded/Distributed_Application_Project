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

        public List<FilmDTO> GetFilms()
        {
            return filmService.Get();
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
                return "Film's not deleted";
            }
            else
            {
                return "Film's deleted";
            }
        }
    }
}
