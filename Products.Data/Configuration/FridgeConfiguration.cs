using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace Products_API.Configuration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData
                (
                    new Fridge
                    {
                        Id = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"),
                        Name = "My fridge",
                        OwnerName = "Anton Pupkin",
                        FridgeModelId = new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3")
                    },
                    new Fridge
                    {
                        Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                        Name = "JJ",
                        OwnerName = "Artem Petrov",
                        FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                    }
                );
        }
    }
}
