using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
        public override string ToString()
        {
            // return $"Id: {Id}; Name: {Name}; {Products.Count}";
            return Name;
        }
    }
}
