using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {
            List<FilmVM> filmVM = new List<FilmVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                foreach (var item in service.GetFilms()) {
                    filmVM.Add(new FilmVM(item));
                }
            }
            return View(filmVM);
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmVM filmVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        FilmDTO filmDTO = new FilmDTO
                        {
                            Title = filmVM.Title,
                            Publishment = filmVM.Publishment,
                            Price = filmVM.Price,
                            Sales = filmVM.Sales,
                            Crew = filmVM.Crew,
                            Comment = filmVM.Comment
                        };
                        service.PostFilm(filmDTO);
                        

                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch { return View(); }
        }
        public ActionResult Delete(int id) {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                service.DeleteFilm(id);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id){
            FilmVM filmVM = new FilmVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                filmVM = new FilmVM(service.GetFilmByID(id));
                    }
            return View(filmVM);
        }
       /* public ActionResult Edit(int id)
        {
            EditClientModel model = null;
            if (id != null)
            {
                model = new EditClientModel(getDbContext.getDb().Clients.Where(i => i.id == id).First());
            }
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(EditClientModel model)
        {
            
                var client = getDbContext.getDb().Clients.Where(i => i.id == model.id).First();
                client.clientFirstName = model.firsName;
                client.clientSecondName = model.secondName;
                client.phoneNumber = model.phone;
                getDbContext.getDb().SaveChanges();
                return View("Done");
            
        }
       */
    }
}