using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Models
{
    [Table("fridge_products")]
    public class FridgeProduct
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge products quantity is required field.")]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Models.Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Fridge))]
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }
    }
}
