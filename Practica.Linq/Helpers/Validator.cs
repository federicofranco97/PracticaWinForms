using PracticaWinForms.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Linq.Helpers
{
    public class Validator
    {
        public string Mensaje(string practica, bool resultado)
        {
            return practica + ": " + (resultado ? "Bien" : "Mal");
        }

    

        public void FillData(ref List<User> users, ref List<Product> prods)
        {
            string[] products = new string[]
            {
                "Smartphone", "Laptop", "Smartwatch", "Headphones", "Tablet",
                "Camera", "Wireless Earbuds", "Gaming Console", "Printer", "Fitness Tracker",
                "Monitor", "External Hard Drive", "Bluetooth Speaker", "Keyboard", "Mouse",
                "TV", "Home Assistant", "Coffee Maker", "Toaster", "Blender",
                "Vacuum Cleaner", "Air Purifier", "Hair Dryer", "Microwave", "Oven",
                "Refrigerator", "Washing Machine", "Dryer", "Smart Thermostat", "Router"
           };
            string pwd = "d3mopassw0rd";
            Random random = new Random();
            Random random2 = new Random();
            //Cargar admin
            users.Add(new User()
            {
                ID = Guid.NewGuid(),
                Password = "admin",
                UserName = "admin",
                UserRole = Role.Administrator
            });
            users.Add(new User()
            {
                ID = Guid.NewGuid(),
                Password = "Marcos",
                UserName = "Marcos",
                UserRole = Role.Administrator
            });
            //Cargar demas Usuarios
            for (int i = 1; i < 30; i++)
            {
                users.Add(new User()
                {
                    ID = Guid.NewGuid(),
                    Password = pwd,
                    UserName = "User #" + i,
                    UserRole = Role.User
                });
            }
            //Cargar Productos
            for (int i = 0; i < 30; i++)
            {
                prods.Add(new Product()
                {
                    ID = Guid.NewGuid(),
                    Name = products[i],
                    Price = Math.Round((decimal)(random.NextDouble() * 1000), 2),
                    Stock = random.Next(1, 100)

                });
            }
        }

        #region Validators

        internal bool Validar1(User pr1, List<User> users)
        {
            return users.FirstOrDefault(u => u.UserName.ToLower() == "marcos") == pr1;
        }

        internal bool Validar2(List<User> pr, List<User> users)
        {
            return users.Where(u => u.UserRole == Role.Administrator) == pr;
        }

        internal bool Validar3(List<Product> practica3, List<Product> productList)
        {
            return productList.Where(p => p.Price > 50).ToList() == practica3;
        }

        internal bool Validar4(List<Product> practica4, List<Product> productList)
        {
            return productList.Where(p => p.Stock < 20).ToList() == practica4;
        }

        internal bool Validar5(int practica5, List<User> userList)
        {
            return userList.Where(u => u.UserRole == Role.Administrator).Count() == practica5;
        }

        internal bool Validar6(int practica6, List<User> userList)
        {
            return userList.Where(u => u.UserRole == Role.User).Count() == practica6;
        }
        #endregion
    }
}
