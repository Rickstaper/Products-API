using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.DataTransferObject
{
    public class FridgeProductForCreationDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
