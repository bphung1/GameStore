using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Library.Interface;
using GameStore.Library.Model;
using GameStore.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IGameStoreRepository Repo { get; }

        public CustomerController(IGameStoreRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: CustomerController
        public ActionResult Index([FromQuery] string search = "")
        {
            IEnumerable<Customer> customers = Repo.GetCustomers(search);
            IEnumerable<CustomerViewModel> viewModels = customers.Select(x => new CustomerViewModel
            {
                CustomerId = x.CustomerID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                GameOrders = x.GameOrders.Select(y => new GameOrderViewModel())

            }) ;

            return View(viewModels);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = Repo.GetCustomerById(id);

            var viewModels = new CustomerViewModel
            {
                CustomerId = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                ListOfGameOrder = Repo.GetGameOrdersByCustomerId(customer.CustomerID)
            };

            return View(viewModels);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
