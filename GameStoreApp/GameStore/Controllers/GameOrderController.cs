using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebUI.Controllers
{
    public class GameOrderController : Controller
    {
        // GET: GameOrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameOrderController/Create
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

        // GET: GameOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameOrderController/Edit/5
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

        // GET: GameOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameOrderController/Delete/5
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
