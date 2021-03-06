﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Library.Interface;
using GameStore.Library.Model;
using GameStore.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GameStore.WebUI.Controllers
{
    public class GameOrderController : Controller
    {
        public IGameStoreRepository Repo { get; }

        public GameOrderController(IGameStoreRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: GameOrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameOrderController/Details/5
        public ActionResult Details(int id)//orderId
        {
            GameOrder gameOrder = Repo.GetGameOrderById(id);
            var customerId = Repo.GetCustomerById(gameOrder.CustomerID);

            var game = Repo.GetGameById(gameOrder.GameID);

            var viewModel = new GameOrderViewModel
            {
                Quantity = gameOrder.Quantity,
                Game = game,
                Customer = Repo.GetCustomerById(gameOrder.CustomerID),
                OrderID = gameOrder.OrderID,
                CustomerId = gameOrder.CustomerID,
                StoreId = gameOrder.StoreID,
                StoreLocation = Repo.GetStoreById(gameOrder.StoreID),
                OrderTime = gameOrder.OrderTime
            };

            return View(viewModel);
        }

        // GET: GameOrderController/Create
        public ActionResult Create([FromQuery]int customerId)
        {
            var storeList = new List<SelectListItem>();
            foreach (var store in Repo.GetStoreLocations())
            {
                storeList.Add(new SelectListItem
                { 
                    Value = store.StoreName.ToString(), Text = store.StoreName
                });
            }

            var gameList = new List<SelectListItem>();
            foreach (var item in Repo.GetGames())
            {
                gameList.Add(new SelectListItem
                {
                    Value = item.GameName.ToString(),
                    Text = item.GameName
                });
            }

            var gameOrder = new GameOrderViewModel
            {
                Customer = Repo.GetCustomerById(customerId),
                ListOfGames = gameList,
                CustomerId = customerId,
                ListOfStores = storeList,
                OrderTime = DateTime.Now
            };

            return View(gameOrder);
        }

        // POST: GameOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameOrderViewModel viewModel)
        {
            try
            {
                GameOrder gameOrder = new GameOrder();
                gameOrder.CustomerID = viewModel.CustomerId;
                gameOrder.StoreID = Repo.GetStoreByName(viewModel.StoreName).StoreID;
                gameOrder.OrderTime = DateTime.Now;
                gameOrder.GameID = Repo.GetGameByGameName(viewModel.GameName).GameID;
                gameOrder.Quantity = viewModel.Quantity;

                Repo.AddOrder(gameOrder);
                Repo.Save();

                return RedirectToAction("Index", "Customer");
            }
            catch
            {
                return RedirectToAction("Index", "Customer");
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
