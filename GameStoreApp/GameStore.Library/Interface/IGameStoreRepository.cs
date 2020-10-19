using GameStore.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library.Interface
{
    public interface IGameStoreRepository
    {
        IEnumerable<Customer> GetCustomers(string search = null);
        Customer GetCustomer(string firstName, string lastName);
        Customer GetCustomerById(int customerId);
        int CustomerIdFromOrderId(int orderId);
        IEnumerable<Game> GetGames();
        Game GetGameById(int gameId);
        Game GetGameByGameName(string gameName);
        IEnumerable<GameOrder> GetGameOrders();
        IEnumerable<GameOrder> GetGameOrdersByCustomerId(int customerId);
        GameOrder GetGameOrderById(int gameOrderId);
        GameOrder GetRecentGameOrderByCustomerId(int customerId);
        IEnumerable<StoreLocation> GetStoreLocations(string search = null);
        StoreLocation GetStoreById(int storeId);
        int GetStoreIdFromOrderId(int orderId);
        StoreLocation GetStoreByName(string storeName);
        void AddOrder(GameOrder gameOrder);
        void Save();
        void CreateOrder(GameOrder gameOrder);
    }
}
