using ApplicationService.DTOs;
using MVC.SOAPService;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string query)
        {
            List<UserVM> userVM = new List<UserVM>();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client()){
                foreach (var item in service.GetUsers(query)) {
                    userVM.Add(new UserVM(item));
                }  
            }
                return View(userVM);
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserVM userVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserDTO userDTO = new UserDTO
                        {
                            Name = userVM.Name,
                            Age = userVM.Age,
                            Budget = userVM.Budget,
                            Phone = userVM.Buyed,
                            Favorites = userVM.Favorites,
                            Description = userVM.Description
                        };
                        service.PostUser(userDTO);
                        return RedirectToAction("Index");

                    }

                }
                else
                {
                    return View();
                }
            }
            catch { return View(); }
        }
        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteUser(id);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            UserVM userVM = new UserVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
               
                userVM = new UserVM(service.GetUserByID(id));

            }
            return View(userVM);
        }
        public ActionResult Edit(int id, string query)
        {
            UserVM userVM = new UserVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                userVM = new UserVM(service.GetUserByID(id));
            }
            return View(userVM);
        }

        [HttpPost]
        public ActionResult Edit(UserVM userVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        UserDTO userDTO = new UserDTO
                        {
                            Id = userVM.Id,
                            Name = userVM.Name,
                            Age = userVM.Age,
                            Budget = userVM.Budget,
                            Phone = userVM.Buyed,
                            Favorites = userVM.Favorites,
                            Description = userVM.Description

                        };
                        service.PostUser(userDTO);

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