using PracticaWinForms.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace PracticaWinForms.Business
{
    public static class Engine
    {
        //Storage helper
        static StorageManager storage = new StorageManager();
        public static List<User> Users = new List<User>();
        public static List<Product> Products = new List<Product>();
        public static List<Purchase> Purchases = new List<Purchase>();

        #region FilePaths
        //Storage files location
        static string UsersFile = AppContext.BaseDirectory + "/Users.txt";
        static string ProductsFile = AppContext.BaseDirectory + "/Products.txt";
        static string PurchasesFile = AppContext.BaseDirectory + "/Purchases.txt";
        #endregion

        public static void AddProduct(string Name, int Stock, decimal Price)
        {
            Product prod = new Product();
            prod.ID = Guid.NewGuid();
            prod.Name = Name;
            prod.Stock = Stock;
            prod.Price = Price;
            Products.Add(prod);
        }

        public static bool Login(string username, string password)
        {
            if (username == "admin" && password == "admin") return true;
            //If there is any user with the same username and the same password, return true, else false.
            return Users.Any(u => u.UserName == username && u.Password == password);
        }

        /// <summary>
        /// Runs all the startup methods
        /// </summary>
        public static void Initialize()
        {
            //Get the saved users
            var storageUsers = storage.GetStorageFile(UsersFile);
            //Convert from JSON to list
            Users = JsonConvert.DeserializeObject<List<User>>(storageUsers);
            if(Users == null) { Users = new List<User>(); }
            //Get the saved products
            var storageProducts = storage.GetStorageFile(ProductsFile);
            //Convert from JSON to list
            Products = JsonConvert.DeserializeObject<List<Product>>(storageProducts);
            if (Products == null) { Products = new List<Product>(); }
            //Get the saved purchases
            var storagePurchases = storage.GetStorageFile(PurchasesFile);
            //Convert from JSON to list
            Purchases = JsonConvert.DeserializeObject<List<Purchase>>(storagePurchases);
            if (Purchases == null) { Purchases = new List<Purchase>(); }
        }

        public static void SaveProducts(string Content)
        {
            storage.SaveStorageFile(ProductsFile, Content);
        }

        public static void SavePurchases(string Content)
        {
            storage.SaveStorageFile(PurchasesFile, Content);
        }

        public static void SaveUsers(string Content)
        {
            storage.SaveStorageFile(UsersFile, Content);
        }
    }
}
