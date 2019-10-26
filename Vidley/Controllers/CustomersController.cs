using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
       

        public ActionResult Details(int Id = 0)
        {
            var customers = new List<Customer>
            {
              new Customer { Name = "Mike Mulderink" },
              new Customer { Name = "Tnaya Witmer" }
            };

            if (Id < 1 || customers.Count < Id)
            {
                var nullCustomer = new List<Customer>
                {
                    new Customer { Name = "Customer does not exist" }
                };

                var nullViewModel = new CustomerViewModel
                {
                    Customer = nullCustomer[0]
                };

                return View(nullViewModel);
            }
                
            var viewModel = new CustomerViewModel
            {
                Customer = customers[Id - 1]
            };

            if (string.IsNullOrEmpty(viewModel.Customer.Name))
                viewModel.Customer.Name = "Customer Does not exist";
           
            return View(viewModel);
        }

        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
              new Customer { Name = "Mike Mulderink" },
              new Customer { Name = "Tnaya Witmer" }
            };

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }
    }
}