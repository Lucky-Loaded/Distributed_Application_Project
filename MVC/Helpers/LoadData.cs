using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadData
    {
        public static SelectList LoadFilmData() {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                return new SelectList(service.GetFilms(), "Id", "Title");
            }
        }
        public static SelectList LoadUserData()
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetUsers(), "Id", "Name");
            }
        }
    }
}