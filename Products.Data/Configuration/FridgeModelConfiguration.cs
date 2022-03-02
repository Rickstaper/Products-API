using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Models;
using System;

namespace Products.Data.Configuration
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData
                (
                    new FridgeModel
                    {
                        Id = new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3"),
                        Name = "SAMSUNG 253 L Frost Free Double Door 3 Star Convertible Refrigerator  (Elegant Inox, RT28T3743S8/HL)",
                        Year = 2020
                    },
                    new FridgeModel
                    {
                        Id = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1"),
                        Name = "Whirlpool 240 L Frost Free Triple Door Refrigerator  (Magnum Steel, FP 263D PROTTON ROY MAGNUM STEEL(N))",
                        Year = 2020
                    }
                );
        }
    }
}
