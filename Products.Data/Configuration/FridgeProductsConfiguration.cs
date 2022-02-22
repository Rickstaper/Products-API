using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Products_API.Configuration
{
    public class FridgeProductsConfiguration : IEntityTypeConfiguration<FridgeProducts>
    {
        public void Configure(EntityTypeBuilder<FridgeProducts> builder)
        {
            builder.HasData
                (
                    new FridgeProducts
                    {
                        Id = new Guid("7f330a10-22ce-4d15-9494-5248780c2ce1"),
                        Quantity = 2,
                        ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        FridgeId = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3")
                    },
                    new FridgeProducts
                    {
                        Id = new Guid("6f130a10-22ce-4d15-9494-5248780c2ce1"),
                        Quantity = 1,
                        ProductId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3")
                    }
                );
        }
    }
}
