using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using System.Data.Entity;
using VidlyTwo.ViewModel;

namespace VidlyTwo.Controllers
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


        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*
        //      NEW
        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*
        //      CREATE
        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {

            //var x = _context.MembershipTypes.ToList();

            if (!ModelState.IsValid)
            {
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();

                return View("CustomerForm", viewModel);
            }

            var customerId = viewModel.Customer.Id;

            if (customerId != 0)
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customerId);

                customerInDb.Id = viewModel.Customer.Id;
                customerInDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.Birthdate = viewModel.Customer.Birthdate;

            }
            else
            {

                Customer custom = new Customer();

                custom.Id = viewModel.Customer.Id;
                custom.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                custom.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                custom.Name = viewModel.Customer.Name;
                custom.Birthdate = viewModel.Customer.Birthdate;

                _context.Customers.Add(custom);

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
            //return View("New", viewModel);
        }


        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*


        // GET: Customers
        public ViewResult Index()
        {

            //  Add Reference System.Data.Entity
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            ViewBag.Customers = customers;

            return View();

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.Customers = customer;

            return View();

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", viewModel);
        }
    }
}