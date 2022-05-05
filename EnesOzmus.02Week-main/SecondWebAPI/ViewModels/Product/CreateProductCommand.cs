﻿namespace SecondWebAPI.ViewModels
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
