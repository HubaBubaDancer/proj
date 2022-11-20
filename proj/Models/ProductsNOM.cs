using System;

namespace proj.Models
{
    public class ProductsNOM : BaseDbItem
    {
        public string Name { get; set; }
        
        public double Price { get; set; }

        public string  UnitOfMeasurement { get; set; }

        public float Amount { get; set; }
        
        public string? Description { get; set; }
    }
    
}