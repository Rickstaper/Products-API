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
    public class FridgeTests
    {
        private readonly IMapper _mapper;

        public FridgeTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        /// <summary>
        /// Test FridgeController using GetAllFridgesAsync.
        /// Should return 'ok' status code without data.
        /// </summary>
        /// <param name="fridge">object with data from GetFridges static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridges))]
        public async Task GetFridges_ShouldReturnOk_NoData(Fridge fridge)
        {

            var fakeRepositoryManager = new FakeRepositoryManager();

            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridge.FridgeModelId, false))
                .Returns(Task.FromResult(new FridgeModel()));

            fakeRepositoryManager.Mock.Setup(frp => frp.Fridge.GetAllFridgesAsync(fridge.FridgeModelId, false))
                .Returns(Task.FromResult((IEnumerable<Fridge>)(new List<Fridge>())));

            var fakeLogger = new FakeLogger<FridgeController>();

            FridgeController controller = new FridgeController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridges(fridge.FridgeModelId);

            Assert.IsNotNull(response, "Result of GetFridges method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "Status code of okResult is'n 200.");

            Assert.IsNotNull(okResult.Value, "okResult object value is null.");

            var fridgeModelResult = okResult.Value as IEnumerable<FridgeDto>;

            Assert.IsNotNull(fridgeModelResult, "okResult.Value as FridgeDto object is null.");
        }

        /// <summary>
        /// Test FridgeController using GetAllFridgesAsync.
        /// Should return 'ok' status code with data from fridge. 
        /// </summary>
        /// <param name="fridge">object with data from GetFridges static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridges))]
        public async Task GetFridges_ShouldReturnOk_WithData(Fridge fridge)
        {

            var fakeRepositoryManager = new FakeRepositoryManager();

            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridge.FridgeModelId, false))
                .Returns(Task.FromResult(new FridgeModel()));

            fakeRepositoryManager.Mock.Setup(frp => frp.Fridge.GetAllFridgesAsync(fridge.FridgeModelId, false))
                .Returns(Task.FromResult((IEnumerable<Fridge>)(new List<Fridge>()
                {
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
                    },
                })));

            var fakeLogger = new FakeLogger<FridgeController>();

            FridgeController controller = new FridgeController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridges(fridge.FridgeModelId);

            Assert.IsNotNull(response, "Result of GetFridges method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "Status code of okResult is'n 200.");

            Assert.IsNotNull(okResult.Value, "okResult object value is null.");

            var fridgesResult = okResult.Value as IEnumerable<FridgeDto>;

            Assert.IsNotNull(fridgesResult, "okResult.Value as FridgeDto object is null.");

            Assert.AreEqual(fridge.Id, fridgesResult.Where(fr => fr.Id.Equals(fridge.Id)).SingleOrDefault().Id, "Id of fridgesResult isn't id of fridge.");
            Assert.AreEqual(fridge.Name, fridgesResult.Where(fr => fr.Name.Equals(fridge.Name)).SingleOrDefault().Name, "Name of fridgesResult isn't name of fridge.");
            Assert.AreEqual(fridge.OwnerName, fridgesResult.Where(fr => fr.OwnerName.Equals(fridge.OwnerName)).SingleOrDefault().OwnerName, "OwnerName of fridgesResult isn't OwnerName of fridge.");
        }

        /// <summary>
        /// Test FridgeController using GetFridgeByIdAsync.
        /// Should return 'ok' status code without data from fridge.
        /// </summary>
        /// <param name="fridge">object with data from GetFridges static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridges))]
        public async Task GetFridgeByIdAsync_ShouldReturnOk_NoData(Fridge fridge)
        {
            var fakeRepositoryManager = new FakeRepositoryManager();

            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridge.FridgeModelId, false))
                .Returns(Task.FromResult(new FridgeModel()));

            fakeRepositoryManager.Mock.Setup(frp => frp.Fridge.GetFridgeByIdAsync(fridge.FridgeModelId, fridge.Id, false))
                .Returns(Task.FromResult(new Fridge()));

            var fakeLogger = new FakeLogger<FridgeController>();

            FridgeController controller = new FridgeController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridgeByIdAsync(fridge.FridgeModelId, fridge.Id);

            Assert.IsNotNull(response, "Result of GetFridges method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "Status code of okResult is'n 200.");

            Assert.IsNotNull(okResult.Value, "okResult object value is null.");

            var fridgeResult = okResult.Value as FridgeDto;

            Assert.IsNotNull(fridgeResult, "okResult.Value as FridgeDto object is null.");
        }

        /// <summary>
        /// Test FridgeController using GetFridgeByIdAsync.
        /// Should return 'ok' status code with data from fridge.
        /// </summary>
        /// <param name="fridge">object with data from GetFridges static method</param>
        /// <returns>Task</returns>
        [TestCaseSource(nameof(GetFridges))]
        public async Task GetFridgeByIdAsync_ShouldReturnOk_WithData(Fridge fridge)
        {
            var fakeRepositoryManager = new FakeRepositoryManager();

            fakeRepositoryManager.Mock.Setup(frp => frp.FridgeModel.GetFridgeModelAsync(fridge.FridgeModelId, false))
                .Returns(Task.FromResult(new FridgeModel()));

            fakeRepositoryManager.Mock.Setup(frp => frp.Fridge.GetFridgeByIdAsync(fridge.FridgeModelId, fridge.Id, false))
                .Returns(Task.FromResult(new Fridge()
                {
                    Id = fridge.Id,
                    Name = fridge.Name,
                    OwnerName = fridge.OwnerName
                }));

            var fakeLogger = new FakeLogger<FridgeController>();

            FridgeController controller = new FridgeController(fakeRepositoryManager.Repository, fakeLogger.Logger, _mapper);

            var response = await controller.GetFridgeByIdAsync(fridge.FridgeModelId, fridge.Id);

            Assert.IsNotNull(response, "Result of GetFridges method is null.");

            var okResult = response as OkObjectResult;

            Assert.AreEqual(((int)HttpStatusCode.OK), okResult.StatusCode, "Status code of okResult is'n 200.");

            Assert.IsNotNull(okResult.Value, "okResult object value is null.");

            var fridgeResult = okResult.Value as FridgeDto;

            Assert.IsNotNull(fridgeResult, "okResult.Value as FridgeDto object is null.");

            Assert.AreEqual(fridge.Id, fridgeResult.Id, "Id of fridgeResult isn't id of fridge.");
            Assert.AreEqual(fridge.Name, fridgeResult.Name, "Name of fridgeResult isn't name of fridge.");
            Assert.AreEqual(fridge.OwnerName, fridgeResult.OwnerName, "OwnerName of fridgeResult isn't OwnerName of fridge.");
        }

        private static IEnumerable<Fridge> GetFridges()
        {
            yield return new Fridge
            {
                Id = new Guid("6b572a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "My fridge",
                OwnerName = "Anton Pupkin",
                FridgeModelId = new Guid("5f390a10-94ce-4d15-9494-5248780c2ce3")
            };
            yield return new Fridge
            {
                Id = new Guid("5a572a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "JJ",
                OwnerName = "Artem Petrov",
                FridgeModelId = new Guid("1b240a10-22ce-4d15-9494-5248780c2ce1")
            };
        }
    }
}
