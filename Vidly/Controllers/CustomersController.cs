using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //Crea un dbcontext de aplicacion
        private ApplicationDbContext _context;

        //Inicializa el constructor
        public CustomersController()
        {
            //Inicializa el dbContext
            _context = new ApplicationDbContext();
        }
        //Sobreescribe el dispose 
        protected override void Dispose(bool disposing)
        {
            //cierra el context
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipType.ToList()
                };

                return View("CustomerForm",viewModel);
            }
            if(customer.Id ==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;

            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        //Crea el indice
        public ViewResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //return View(customers);
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        //Muestra el detalle de un customer
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public  ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }


    }

}
