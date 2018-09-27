using System.Linq;
using System.Web.Mvc;
using CustomersModule.Data;
using CustomersModule.Models;

namespace CustomersModule.Controllers
{
    public class CustomersController : Controller
    {
      
        public ActionResult Index()
        {
            using (var dbContext = new CustomerContext())
            {
                var model = dbContext.Customers.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new CustomerContext())
                {
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                }            
            }
            else
            {
                return View("Create", customer);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var dbContext = new CustomerContext())
            {
                var model = dbContext.Customers.Find(id);
                if (model == null) return RedirectToAction("Index");
                return View(model);
            }
          
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
           
            if (ModelState.IsValid)
            {
                using (var dbContext = new CustomerContext())
                {
                    var customerRecord = dbContext.Customers.Find(customer.ID);
                    if (customerRecord != null)
                    {
                        customerRecord.Name = customer.Name;
                        customerRecord.Surname = customer.Surname;
                        customerRecord.Street = customer.Street;
                        customerRecord.HouseNumber = customer.HouseNumber;
                        customerRecord.ZipCode = customer.ZipCode;
                        customerRecord.City = customer.City;
                        customerRecord.TelephoneNumber = customer.TelephoneNumber;

                        dbContext.SaveChanges();
                    }
                }
            }
            else
            {
                return View("Edit", customer);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            using (var dbContext = new CustomerContext())
            {
                var customerRecord = dbContext.Customers.Find(id);
                if (customerRecord != null)
                {
                    dbContext.Customers.Remove(customerRecord);
                    dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

    }
}