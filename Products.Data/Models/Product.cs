using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Models
{
    [Table("products")]
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge model name is required field.")]
        public string Name { get; set; }

        [DefaultValue(0)]
        public int DefaultQuantity { get; set; }

        public byte[] Image { get; set; }

        public ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
