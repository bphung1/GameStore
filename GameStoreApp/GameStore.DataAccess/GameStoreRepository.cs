using GameStore.DataAccess.Entities;
using GameStore.Library.Interface;
using GameStore.Library.Model;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.Customer> GetCustomers(string search = null)
        {
            return Mapper.Map(_dbContext.Customer);
        }

        public Library.Model.Game GetGameById(int gameId)
        {
            throw new NotImplementedException();
        }

        public Library.Model.GameOrder GetGameOrderById(int gameOrderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.GameOrder> GetGameOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.GameOrder> GetGameOrdersByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public Library.Model.GameOrder GetRecentGameOrderByCusomterId(int customerId)
        {
            throw new NotImplementedException();
        }

        public Library.Model.StoreLocation GetStoreById(int storeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Model.StoreLocation> GetStoreLocations(string search = null)
        {
            throw new NotImplementedException();
        }

        public int StoreIdFromOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
