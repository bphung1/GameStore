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
        IEnumerable<Game> GetGames();
        Game GetGameById(int gameId);
        IEnumerable<GameOrder> GetGameOrders();
        IEnumerable<GameOrder> GetGameOrdersByCustomerId(int customerId);
        GameOrder GetGameOrderById(int gameOrderId);
        GameOrder GetRecentGameOrderByCusomterId(int customerId);
        IEnumerable<StoreLocation> GetStoreLocations(string search = null);
        StoreLocation GetStoreById(int storeId);
        int StoreIdFromOrderId(int orderId);

    }
}
