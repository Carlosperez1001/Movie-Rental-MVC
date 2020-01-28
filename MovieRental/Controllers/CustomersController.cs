using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {

        public List<Customer> GetCustomers() {
            var CustomerList = new List<Customer> {
                 new Customer{Id = 1, Name = "Bobby B." },
                 new Customer{Id = 2, Name = "Marky Mark" }
            };
           
            return (CustomerList); 
        }

        // GET: Customer
        public ActionResult Index()
        {
            var CustomerModel = new CustomerListViewModel
            {
                CustomerList = GetCustomers()
            };
            return View(CustomerModel);
        }

        [Route("customer/details/{ID}")]
        public ActionResult SelectedCustomer(int ID) {
            var list = new List<Customer> { };
            list = GetCustomers();
            Customer SCustomer = list.Find(Customer => Customer.Id == ID);


            var Viewodel =  new SelectedCustomerViewModel{
                Customer = SCustomer
            };

            return View(Viewodel);

        }
    }

}