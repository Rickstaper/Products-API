﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Products
    {
        [Column("PoductId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge model name is required field.")]
        public string Name { get; set; }

        [DefaultValue(0)]
        public int DefaultQuantity { get; set; }

        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
