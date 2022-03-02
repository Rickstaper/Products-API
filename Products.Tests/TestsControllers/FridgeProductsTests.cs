using AutoMapper;
using NUnit.Framework;
using Products.Data.Models;
using Products_API.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Products_API.Mappings;
using Products.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Products.Data.DataTransferObject;
using System.Linq;


namespace Products.Tests.TestsControllers
{
    public class FridgeProductsTests
    {
        private readonly IMapper _mapper;

        public FridgeProductsTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        /// <summary>
        /// Test FridgeProductController using GetFridgeProductsFromFridgeAsync.
        /// Should return 'ok' status code with data from fridgeProduct. 
        /// </summary>
        /// <param name="fridgeProduct">object with data from GetFridgeProducts static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridgeProducts))]
        public async Task GetFridgeProductsFromFridgeAsync_ShouldReturnOk_WithData(FridgeProduct fridgeProduct)
        {
            var fakeRepositoryManager = new FakeRepositoryManager();

            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridgeProduct.Fridge.FridgeModelId, false))
               .Returns(Task.FromResult(new FridgeModel()));

            fakeRepositoryManager.Mock.Setup(frp => frp.Fridge.GetFridgeByIdAsync(fridgeProduct.Fridge.FridgeModelId, fridgeProduct.FridgeId, false))
                .Returns(Task.FromResult(new Fridge()));

            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeProduct.GetAllFridgeProductsAsync(fridgeProduct.Fridge.FridgeModelId, fridgeProduct.FridgeId, false))
                .Returns(Task.FromResult((IEnumerable<FridgeProduct>)(new List<FridgeProduct>()
                {
                    new FridgeProduct()
                    {
                        Id = new Guid("7f330a10-22ce-4d15-9494-5248780c2ce1"),
                        Quantity = 2,
                        ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        FridgeId = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"),
                        Fridge = new Fridge
                        {
                            Id = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "My fridge",
                            OwnerName = "Anton Pupkin",
                            FridgeModelId = new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3")
                        }
                    },
                    new FridgeProduct()
                    {
                        Id = new Guid("6f130a10-22ce-4d15-9494-5248780c2ce1"),
                        Quantity = 1,
                        ProductId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                        Fridge = new Fridge
                        {
                            Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "JJ",
                            OwnerName = "Artem Petrov",
                            FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                        }
                    },
                    new FridgeProduct()
                    {
                        Id = new Guid("3a130a10-22ce-4d15-9494-5248780c2ce1"),
                        Quantity = 0,
                        ProductId = new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"),
                        FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                        Fridge = new Fridge
                        {
                            Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "JJ",
                            OwnerName = "Artem Petrov",
                            FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                        }
                    },
                    new FridgeProduct()
                    {
                        Id = new Guid("3b130a10-22ce-4d15-9494-5248780c2ce1"),
                        Quantity = 0,
                        ProductId = new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"),
                        FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                        Fridge = new Fridge
                        {
                            Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "JJ",
                            OwnerName = "Artem Petrov",
                            FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                        }
                    }
                })));

            var fakeLogger = new FakeLogger<FridgeProductController>();

            FridgeProductController controller = new FridgeProductController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridgeProductsFromFridgeAsync(fridgeProduct.Fridge.FridgeModelId, fridgeProduct.FridgeId);

            Assert.IsNotNull(response, "Result of GetFridges method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "Status code of okResult is'n 200.");

            Assert.IsNotNull(okResult.Value, "okResult object value is null.");

            var fridgeProductsResult = okResult.Value as IEnumerable<FridgeProductDto>;

            Assert.IsNotNull(fridgeProductsResult, "okResult.Value as FridgeDto object is null.");

            Assert.AreEqual(fridgeProduct.Id, fridgeProductsResult.Where(fr => fr.Id.Equals(fridgeProduct.Id)).SingleOrDefault().Id, "Id of fridgeProductsResult isn't id of fridgeProduct.");
            Assert.AreEqual(fridgeProduct.Quantity, fridgeProductsResult.Where(fr => fr.Id.Equals(fridgeProduct.Id)).SingleOrDefault().Quantity, "Quantity of fridgeProductsResult isn't quantity of fridgeProduct.");
        }

        /// <summary>
        /// Method for get source fridge products
        /// </summary>
        /// <returns>IEnumerable of fridge products</returns>
        private static IEnumerable<FridgeProduct> GetFridgeProducts()
        {
            yield return new FridgeProduct
            {
                Id = new Guid("7f330a10-22ce-4d15-9494-5248780c2ce1"),
                Quantity = 2,
                ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                FridgeId = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"),
                Fridge = new Fridge
                {
                    Id = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "My fridge",
                    OwnerName = "Anton Pupkin",
                    FridgeModelId = new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3")
                }
            };
            yield return new FridgeProduct
            {
                Id = new Guid("6f130a10-22ce-4d15-9494-5248780c2ce1"),
                Quantity = 1,
                ProductId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                Fridge = new Fridge
                {
                    Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "JJ",
                    OwnerName = "Artem Petrov",
                    FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                }
            };
            yield return new FridgeProduct
            {
                Id = new Guid("3a130a10-22ce-4d15-9494-5248780c2ce1"),
                Quantity = 0,
                ProductId = new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"),
                FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                Fridge = new Fridge
                {
                    Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "JJ",
                    OwnerName = "Artem Petrov",
                    FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                }
            };
            yield return new FridgeProduct
            {
                Id = new Guid("3b130a10-22ce-4d15-9494-5248780c2ce1"),
                Quantity = 0,
                ProductId = new Guid("9f490a70-94ce-4d15-9494-5248280c2ce3"),
                FridgeId = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                Fridge = new Fridge
                {
                    Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "JJ",
                    OwnerName = "Artem Petrov",
                    FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
                }
            };
        }
    }
}
