using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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


        //Crea el indice
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        //Muestra el detalle de un customer
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        ////Obtiene los customers
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>

        //    {
        //            new Customer { Id = 1, Name = "John Smith" },
        //            new Customer { Id = 2, Name = "Mary Williams" }
        //     };
        //}

    }

}
