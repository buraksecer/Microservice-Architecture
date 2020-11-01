using Basket.Entities.Abstract;

namespace Basket.Entities.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
    }
}
