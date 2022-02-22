using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Fridge
    {
        [Column("FidgeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge name is required field.")]
        public string Name { get; set; }

        [Column("Owner_name")]
        public string OwnerName { get; set; }

        [ForeignKey(nameof(FridgeModel))]
        [Column("Model_id")]
        public Guid FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }

        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
