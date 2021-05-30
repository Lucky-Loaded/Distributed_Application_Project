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
        public ActionResult Index()
        {

            List<OrderVM> orderVMs = new List<OrderVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                foreach (var item in service.GetOrders()) {
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
        
        public ActionResult Create()
        {
            ViewBag.Films = Helpers.LoadData.LoadFilmData();
            ViewBag.Users = Helpers.LoadData.LoadUserData();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM orderVM)
        {

            try
            {
             
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        OrderDTO orderDTO = new OrderDTO
                        {
                            Id_Film = orderVM.Id_Film,
                        Film = new FilmDTO
                        {
                            Id = orderVM.Id_Film,
                            
                        },
                        Id_User = orderVM.Id_User,
                        User = new UserDTO
                        {
                            Id = orderVM.Id_User,
                            
                        },
                        Address = orderVM.Adress,
                        Time_Order = orderVM.Time_Order,
                        Delivery_Price = orderVM.Delivery_Price,
                        Order_Price = orderVM.Order_Price
                    };
                        service.PostOrder(orderDTO);
                      

                    }

                return RedirectToAction("Index");

            }
            catch {
                ViewBag.Films = Helpers.LoadData.LoadFilmData();
                ViewBag.Users = Helpers.LoadData.LoadUserData(); 
                return View(); }
        }
        public ActionResult Delete(int id) {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client()) {
                service.DeleteOrder(id);
            }
            return RedirectToAction("Index");
        }
    }
}