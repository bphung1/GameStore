using GameStore.DataAccess.Entities;
using GameStore.Library.Interface;
using GameStore.Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameStore.DataAccess
{
    class GameStoreRepository : IGameStoreRepository
    {
        private readonly GameStoreMVCContext _dbContext;

        public GameStoreRepository(GameStoreMVCContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public Library.Model.Customer GetCustomer(string firstName, string lastName)
        {
            var customer = _dbContext.Customer.FirstOrDefault(c => c.FirstName.Contains(firstName) && c.LastName.Contains(lastName));

            if (customer == null)
            {
                return null;
            }

            return new Library.Model.Customer
            { 
                CustomerID = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

        }

        public Library.Model.Customer GetCustomerById(int customerId)
        {
            //Entities.Customer customer = _dbContext.Customer.Include(c => c.GameOrder)
            //    .AsNoTracking().First(r => r.CustomerId == customerId);
            //return Mapper.Map(customer);
            var customer = _dbContext.Customer.FirstOrDefault(c => c.CustomerId.Equals(customerId));
            if (customer == null)
            {
                return null;
            }

            return new Library.Model.Customer
            { 
                CustomerID = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public IEnumerable<Library.Model.Customer> GetCustomers(string search = null)
        {
            return Mapper.Map(_dbContext.Customer);
        }

        public Library.Model.Game GetGameById(int gameId)
        {
            var game = _dbContext.Game.FirstOrDefault(g => g.GameId.Equals(gameId));
            if (game == null)
            {
                return null;
            }

            return new Library.Model.Game
            {
                GameID = game.GameId,
                GameName = game.GameName,
                Price = (decimal)game.Price
            };
        }

        public Library.Model.GameOrder GetGameOrderById(int gameOrderId)
        {
            Entities.GameOrder gameOrder = _dbContext.GameOrder.AsNoTracking()
                .First(r => r.OrderId == gameOrderId);
            return Mapper.Map(gameOrder);
        }

        public IEnumerable<Library.Model.GameOrder> GetGameOrders()
        {
            return Mapper.Map(_dbContext.GameOrder);
        }

        public IEnumerable<Library.Model.GameOrder> GetGameOrdersByCustomerId(int customerId)
        {
            return Mapper.Map(_dbContext.GameOrder.Where(id => id.CustomerId == customerId).ToList());
        }

        public IEnumerable<Library.Model.Game> GetGames()
        {
            return Mapper.Map(_dbContext.Game);
        }

        public Library.Model.GameOrder GetRecentGameOrderByCusomterId(int customerId)
        {
            var order = _dbContext.GameOrder.OrderByDescending(o => o.OrderId).FirstOrDefault(o => o.CustomerId.Equals(customerId));
            if (order == null)
            {
                return null;
            }

            return new Library.Model.GameOrder
            { 
                OrderID = order.OrderId,
                OrderTime = order.OrderTime,
                CustomerID = order.CustomerId,
                StoreID = order.StoreId
            };
        }

        public Library.Model.StoreLocation GetStoreById(int storeId)
        {
            Entities.StoreLocation storeLocation = _dbContext.StoreLocation.AsNoTracking()
                .First(r => r.StoreId == storeId);
            return Mapper.Map(storeLocation);
        }

        public IEnumerable<Library.Model.StoreLocation> GetStoreLocations(string search = null)
        {
            return Mapper.Map(_dbContext.StoreLocation);
        }

        public int GetStoreIdFromOrderId(int orderId)
        {
            Entities.GameOrder gameOrder = _dbContext.GameOrder.AsNoTracking()
                .First(r => r.OrderId == orderId);
            return gameOrder.StoreId;
        }

        public void AddOrder(Library.Model.GameOrder gameOrder)
        {
            _dbContext.Add(Mapper.Map(gameOrder));
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void CreateOrder(Library.Model.GameOrder gameOrder)
        {
            var ordeEntity = _dbContext.GameOrder;
            Entities.GameOrder newOrderEntity = Mapper.Map(gameOrder);
            _dbContext.SaveChanges();
        }
    }
}
