using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Microsoft.Ajax.Utilities;
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
        public ActionResult Index(string query)
        {
            List<FilmVM> filmVM = new List<FilmVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                foreach (var item in service.GetFilms(query)) {
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
                filmVM = new FilmVM(service.GetFilmById(id));
                    }
            return View(filmVM);
        }
        public ActionResult Edit(int id, string query)
        {
            FilmVM filmVM = new FilmVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                filmVM = new FilmVM(service.GetFilmById(id));
            }
            return View(filmVM);
        }

        [HttpPost]
        public ActionResult Edit(FilmVM filmVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        FilmDTO filmDTO = new FilmDTO
                        {
                            Id = filmVM.Id,
                            Title = filmVM.Title,
                            Publishment = filmVM.Publishment,
                            Price = filmVM.Price,
                            Sales = filmVM.Sales,
                            Crew = filmVM.Crew,
                            Comment = filmVM.Comment

                        };
                        service.PostFilm(filmDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

    }
} 
    
