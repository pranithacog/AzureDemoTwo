
    namespace FoodForAzure.Models
    {
        public class Food
        {
            public int Id { get; set; } // Primary Key
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public bool IsAvailable { get; set; } = true; // Availability Status
        }
    }


