using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaWinForms.Data.Model
{
    public class Purchase
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public Guid UserID { get; set; }
        public List<Product> ProductList { get; set; }
        public decimal Total { get; set; }
    }
}
