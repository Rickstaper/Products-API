using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Models
{
    [Table("fridge_model")]
    public class FridgeModel
    {
        [Column("FridgeModelId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge model name is required field.")]
        public string Name { get; set; }

        public int? Year { get; set; }

        public ICollection<Fridge> Fridges { get; set; }
    }
}
