﻿using Microsoft.AspNetCore.Mvc;
using TryLog.Sentinela.Comparers;
using TryLog.Services.ViewModel;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.ControllerTests
{
    public class StatusControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_GetById(int id)
        {
            var fakes = new FakeContext("StatusControllerTest");
            var fakeStatusService = fakes.FakeStatusService().Object;
            var expected = fakeStatusService.Get(id);
            var controller = new StatusController(fakeStatusService);

            var result = controller.Get(id);
            var actionResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);
            var actual = actionResult.Value as StatusViewModel;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new StatusViewModelIDComparer());
        }
    }
}
