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
    public class StoreLocationController : Controller
    {
        public IGameStoreRepository Repo { get; }

        public StoreLocationController(IGameStoreRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: StoreLocationController
        public ActionResult Index()
        {
            IEnumerable<StoreLocation> storeLocations = Repo.GetStoreLocations();
            IEnumerable<StoreLocationViewModel> viewModels = storeLocations.Select(x => new StoreLocationViewModel
            { 
                StoreID = x.StoreID,
                StoreName = x.StoreName,
                State = x.State
            });

            return View(viewModels);
        }

        // GET: StoreLocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreLocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreLocationController/Create
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

        // GET: StoreLocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreLocationController/Edit/5
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

        // GET: StoreLocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreLocationController/Delete/5
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
