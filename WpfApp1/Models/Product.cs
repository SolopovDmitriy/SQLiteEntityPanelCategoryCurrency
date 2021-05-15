using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfApp1.Models
{
    class Product
    {
        
        public int Id { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public override string ToString()
        {
            // return $"Id: {Id}; Name: {Name}; Price: {Price}; Cat_Id: {Category.Name}";
            return $"{Name} - {Category.Name}";
        }
    }
}
