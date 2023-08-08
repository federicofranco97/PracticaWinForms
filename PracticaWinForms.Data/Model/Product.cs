using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaWinForms.Data.Model
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string DisplayValue => $"{Name} {Price}$";
    }
}
