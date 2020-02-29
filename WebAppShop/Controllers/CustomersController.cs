﻿using System;
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

        //public ActionResult New()
        //{
        //    var membershipTypes = _context.MembershipTypes.ToList();
        //    var modelView = new CustomerFormModelView
        //    {
        //        MembershipTypes = membershipTypes
        //    };

        //    return View("CustomerForm", modelView);
        //}

        //Stosuje się, żeby mieć pewność , że metoda jedynie np. wysyła
        [HttpPost]
        //Metoda aktualizuje i tworzy nowe rekordy do bazy danych
        public ActionResult Save(Customer customer)
        {
            //_context.Customers.Add(customer);

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Słaby sposob na aktualizacje
                //TryUpdateModel(customerInDb, " ", new string[] { "Name", "Email"});

                //Mapper.Map(customer, customerInDb); 

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customerInDb.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //Metoda zwraca widok dla uzytkownika o konkretnym id
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormModelView
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        //Metoda wyswietla szczegoly o uzytkowniku, bez opcji edycji
        // GET: Customer
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

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