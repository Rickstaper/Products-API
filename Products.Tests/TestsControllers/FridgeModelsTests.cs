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

namespace Products.Tests.TestsControllers
{
    public class FridgeModelsTests
    {
        private readonly IMapper _mapper;

        public FridgeModelsTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        /// <summary>
        /// Test FridgeModelController using GetFridgeModelByIdAsync.
        /// Should return 'ok' status code without data.
        /// </summary>
        /// <param name="fridgeModel">object with data from GetFridgeModel static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridgeModels))]
        public async Task GetFridgeModelByIdAsync_ShouldReturnOk_NoData(FridgeModel fridgeModel)
        {
            var fakeRepositoryManager = new FakeRepositoryManager();
            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridgeModel.Id, false))
                .Returns(Task.FromResult(new FridgeModel()));

            var fakeLogger = new FakeLogger<FridgeModelController>();

            FridgeModelController controller = new FridgeModelController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridgeModelByIdAsync(fridgeModel.Id);

            Assert.IsNotNull(response, "Result of GetFridgeModelById method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "Status code of okResult is'n 200.");

            Assert.IsNotNull(okResult.Value, "okResult object value is null.");

            var fridgeModelResult = okResult.Value as FridgeModelDto;

            Assert.IsNotNull(fridgeModelResult, "okResult.Value as FridgeModelDto object is null.");
        }

        /// <summary>
        /// Test FridgeModelController using GetFridgeModelByIdAsync.
        /// Should return 'ok' status code with data from fridgeModel. 
        /// </summary>
        /// <param name="fridgeModel">object with data from GetFridgeModel static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridgeModels))]
        public async Task GetFridgeModelByIdAsync_ShouldReturnOk_WithData(FridgeModel fridgeModel)
        {
            var fakeRepositoryManager = new FakeRepositoryManager();
            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridgeModel.Id, false))
                .Returns(Task.FromResult(new FridgeModel()
                {
                    Id = fridgeModel.Id,
                    Name = fridgeModel.Name,
                    Year = fridgeModel.Year
                }));

            var fakeLogger = new FakeLogger<FridgeModelController>();

            FridgeModelController controller = new FridgeModelController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridgeModelByIdAsync(fridgeModel.Id);

            Assert.IsNotNull(response, "Result of GetFridgeModelById method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "HttpStatusCode of okResult isn't 200.");

            Assert.IsNotNull(okResult.Value, "okResult.Value is null.");

            var fridgeModelResult = okResult.Value as FridgeModelDto;

            Assert.IsNotNull(fridgeModelResult, "okResult.Value as FridgeModelDto is null.");

            Assert.AreEqual(fridgeModel.Id, fridgeModelResult.Id, "Id of fridgeModelResult isn't id of fridgeModel.");
            Assert.AreEqual(fridgeModel.Name, fridgeModelResult.Name, "Name of fridgeModelResult isn't name of fridgeModel.");
            Assert.AreEqual(fridgeModel.Year, fridgeModelResult.Year, "Year of fridgeModelResult isn't year of fridgeModel.");
        }

        /// <summary>
        /// Method for get source fridge models
        /// </summary>
        /// <returns>IEnumerable of fridgeModels</returns>
        private static IEnumerable<FridgeModel> GetFridgeModels()
        {
            yield return new FridgeModel
            {
                Id = new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3"),
                Name = "SAMSUNG 253 L Frost Free Double Door 3 Star Convertible Refrigerator  (Elegant Inox, RT28T3743S8/HL)",
                Year = 2020
            };

            yield return new FridgeModel
            {
                Id = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1"),
                Name = "Whirlpool 240 L Frost Free Triple Door Refrigerator  (Magnum Steel, FP 263D PROTTON ROY MAGNUM STEEL(N))",
                Year = 2020
            };
        }
    }
}
