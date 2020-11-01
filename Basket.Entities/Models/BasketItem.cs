using Basket.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Basket.Entities.Models
{
    public class BasketItem : BaseEntity
    {
        [Required] 
        public int CustomerId { get; set; }

        [Required] 
        public int ProductId { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Girilen değer aralığı {1} - {2} olmalı.")]
        public int Quantity { get; set; }
    }
}
