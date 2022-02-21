using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FridgeProducts
    {
        [Column("FridgeProductsId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge products quantity is required field.")]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Products))]
        public Guid ProductId { get; set; }
        public Products Product { get; set; }

        [ForeignKey(nameof(Fridge))]
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }
    }
}
