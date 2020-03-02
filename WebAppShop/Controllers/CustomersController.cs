using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppShop.Models;
using WebAppShop.ModelsView;

namespace WebAppShop.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var customers = GetCustomers();

            //Metoda, która dynamicznie pobiera dane jako lista 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var modelView = new CustomerFormModelView
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", modelView);
        }

        [HttpPost]
        //Metoda aktualizuje rekordy w bazie danych
        public ActionResult Save(Customer customer)
        {
            //walidacja
            if (!ModelState.IsValid)
            {
                var modelView = new CustomerFormModelView
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", modelView);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                //Single() - zwraca jeden konkretny element
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                
                //Słaby sposob na aktualizacje
                //TryUpdateModel(customerInDb, " ", new string[] { "Name", "Email"});

                //Z użyciem biblioteki
                //Mapper.Map(customer, customerInDb); 

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customerInDb.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            //_context.Set(); //co to robi? sprawdzic te metody

            return RedirectToAction("Index", "Customers");
        }

        //Metoda zwraca widok dla uzytkownika o konkretnym id
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) 
                return HttpNotFound();

            var modelView = new CustomerFormModelView
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", modelView);
        }

        //Metoda wyswietla szczegoly o uzytkowniku, bez opcji edycji
        // GET: Customer
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            //SingleOrDefaul() - zwraca jeden konkretny element lub wartosc domyslna
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult Remove(int id)
        {
            var removeObject = _context.Customers.Single(m => m.Id == id);

            _context.Customers.Remove(removeObject);
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        //[HttpPost]
        //public ActionResult Create(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Customers");
        //}

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{ Id = 1, Name="Anna Gruszka"},
        //        new Customer{ Id = 2, Name="Kasia Ananas"},
        //    };
        //}
    }
}