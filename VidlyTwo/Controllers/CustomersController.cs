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
            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("New", viewModel);
        }

        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*
        //      CREATE
        //^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*^~*

        [HttpPost]
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            Customer custom = new Customer();

            custom.Id = viewModel.Customer.Id;
            custom.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
            custom.MembershipTypeId = viewModel.Customer.MembershipTypeId;
            custom.Name = viewModel.Customer.Name;
            custom.Birthdate = viewModel.Customer.Birthdate;
            
            _context.Customers.Add(custom);

            return View("New", viewModel);
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




    }
}