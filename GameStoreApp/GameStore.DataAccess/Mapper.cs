using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameStore.DataAccess
{
    public static class Mapper
    {
        public static Library.Model.Customer Map(Entities.Customer customer) => new Library.Model.Customer
        {
            CustomerID = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };

        public static Entities.Customer Map(Library.Model.Customer customer) => new Entities.Customer
        {
            CustomerId = customer.CustomerID,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };

        public static Library.Model.Game Map(Entities.Game game) => new Library.Model.Game
        { 
            GameID = game.GameId,
            GameName = game.GameName,
            Price = (decimal)game.Price
        };

        public static Entities.Game Map(Library.Model.Game game) => new Entities.Game
        { 
            GameId = game.GameID,
            GameName = game.GameName,
            Price = game.Price
        };

        public static Library.Model.StoreLocation Map(Entities.StoreLocation storeLocation) => new Library.Model.StoreLocation
        { 
            StoreID = storeLocation.StoreId,
            StoreName = storeLocation.StoreName,
            State = storeLocation.StateName
        };

        public static Entities.StoreLocation Map(Library.Model.StoreLocation storeLocation) => new Entities.StoreLocation
        { 
            StoreId = storeLocation.StoreID,
            StoreName = storeLocation.StoreName,
            StateName = storeLocation.State
        };

        public static Library.Model.GameOrder Map(Entities.GameOrder gameOrder) => new Library.Model.GameOrder
        { 
            OrderID = gameOrder.OrderId,
            StoreID = gameOrder.StoreId,
            GameID = gameOrder.GameId,
            CustomerID = gameOrder.CustomerId,
            OrderTime = gameOrder.OrderTime,
            Quantity = (int)gameOrder.Quantity
        };

        public static Entities.GameOrder Map(Library.Model.GameOrder gameOrder) => new Entities.GameOrder
        { 
            OrderId = gameOrder.OrderID,
            StoreId = gameOrder.StoreID,
            GameId = gameOrder.GameID,
            CustomerId = gameOrder.CustomerID,
            OrderTime = gameOrder.OrderTime,
            Quantity = gameOrder.Quantity
        };

        public static Library.Model.ItemInventory Map(Entities.ItemInventory itemInventory) => new Library.Model.ItemInventory
        { 
            InventoryID = itemInventory.InventoryId,
            StoreID = itemInventory.StoreId,
            GameID = itemInventory.GameId,
            Quantity = (int)itemInventory.Quantity,
            Game = Map(itemInventory.Game),
        };

        public static Entities.ItemInventory Map(Library.Model.ItemInventory itemInventory) => new Entities.ItemInventory
        { 
            InventoryId = itemInventory.InventoryID,
            StoreId = itemInventory.StoreID,
            GameId = itemInventory.GameID,
            Quantity = itemInventory.Quantity,
            Game = Map(itemInventory.Game)
        };

        public static IEnumerable<Library.Model.Customer> Map(IEnumerable<Entities.Customer> customers) => customers.Select(Map);
        public static IEnumerable<Entities.Customer> Map(IEnumerable<Library.Model.Customer> customers) => customers.Select(Map);
        public static IEnumerable<Library.Model.Game> Map(IEnumerable<Entities.Game> games) => games.Select(Map);
        public static IEnumerable<Entities.Game> Map(IEnumerable<Library.Model.Game> games) => games.Select(Map);
        public static IEnumerable<Library.Model.StoreLocation> Map(IEnumerable<Entities.StoreLocation> storeLocations) => storeLocations.Select(Map);
        public static IEnumerable<Entities.StoreLocation> Map(IEnumerable<Library.Model.StoreLocation> storeLocations) => storeLocations.Select(Map);
        public static IEnumerable<Library.Model.GameOrder> Map(IEnumerable<Entities.GameOrder> gameOrders) => gameOrders.Select(Map);
        public static IEnumerable<Entities.GameOrder> Map(IEnumerable<Library.Model.GameOrder> gameOrders) => gameOrders.Select(Map);
        public static IEnumerable<Library.Model.ItemInventory> Map(IEnumerable<Entities.ItemInventory> itemInventories) => itemInventories.Select(Map);
        public static IEnumerable<Entities.ItemInventory> Map(IEnumerable<Library.Model.ItemInventory> itemInventories) => itemInventories.Select(Map);
    }
}
