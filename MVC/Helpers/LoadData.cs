using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadData
    {
        public static SelectList LoadFilmData(string query) {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                return new SelectList(service.GetFilms(query), "Id", "Title");
            }
        }
        public static SelectList LoadUserData(string query)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetUsers(query), "Id", "Name");
            }
        }
    }
}