using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string query)
        {

            List<OrderVM> orderVMs = new List<OrderVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                foreach (var item in service.GetOrders(query)) {
                    orderVMs.Add(new OrderVM(item));
                }
            }
                return View(orderVMs);
        }
        public ActionResult Details(int id)
        {
            OrderVM orderVM = new OrderVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                orderVM = new OrderVM(service.GetOrderByID(id));
            }
            return View(orderVM);
        }
        
        public ActionResult Create(string query)
        {
            ViewBag.Films = Helpers.LoadData.LoadFilmData(query);
            ViewBag.Users = Helpers.LoadData.LoadUserData(query);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM orderVM,string query)
        {

            try
            {
             
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        OrderDTO orderDTO = new OrderDTO
                        {
                            
                        Film = new FilmDTO
                        {
                            Id = orderVM.FilmId,
                            
                        },
                        
                        User = new UserDTO
                        {
                            Id = orderVM.UserId,
                            
                        },
                        Address = orderVM.Adress,
                        TimeOrder = orderVM.TimeOrder,
                        DeliveryPrice = orderVM.DeliveryPrice,
                        OrderPrice = orderVM.OrderPrice
                    };
                        service.PostOrder(orderDTO);
                      

                    }

                return RedirectToAction("Index");

            }
            catch {
                ViewBag.Films = Helpers.LoadData.LoadFilmData(query);
                ViewBag.Users = Helpers.LoadData.LoadUserData(query); 
                return View(); }
        }
        public ActionResult Delete(int id) {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                service.DeleteOrder(id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id, string query)
        {
            OrderVM orderVM = new OrderVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                orderVM = new OrderVM(service.GetOrderByID(id));
                ViewBag.Films = Helpers.LoadData.LoadFilmData(query);
                ViewBag.Users = Helpers.LoadData.LoadUserData(query);
            }
            return View(orderVM);
        }

        [HttpPost]
        public ActionResult Edit(OrderVM orderVM, string query)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        OrderDTO orderDTO = new OrderDTO
                        {
                            Id = orderVM.Id,
                            Film = new FilmDTO
                            {
                                Id = orderVM.FilmId,

                            },

                            User = new UserDTO
                            {
                                Id = orderVM.UserId,

                            },
                            Address = orderVM.Adress,
                            TimeOrder = orderVM.TimeOrder,
                            DeliveryPrice = orderVM.DeliveryPrice,
                            OrderPrice = orderVM.OrderPrice

                        };
                        service.PostOrder(orderDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                ViewBag.Films = Helpers.LoadData.LoadFilmData(query);
                ViewBag.Users = Helpers.LoadData.LoadUserData(query);
                return View();
            }
        }
    }
}