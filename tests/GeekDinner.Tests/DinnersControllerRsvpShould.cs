﻿using System.Collections.Generic;
using System.Linq;
using GeekDinner.ClientModels;
using GeekDinner.Controllers;
using GeekDinner.Core;
using GeekDinner.Core.Interfaces;
using Microsoft.AspNet.Mvc;
using Moq;
using Xunit;

namespace GeekDinner.Tests
{
    public class DinnersControllerAddRsvpShould
    {
        private readonly Mock<IDinnerRepository> _mockRepository;
        private readonly Mock<IDateTime> _mockDateTime;
        public DinnersControllerAddRsvpShould()
        {
            _mockRepository = new Mock<IDinnerRepository>();
            _mockDateTime = new Mock<IDateTime>();
        }

        [Fact]
        public void Return404GivenNotMatchingDinnerId()
        {
            _mockRepository.Setup(r => r.GetById(0)).Returns((Dinner)null);
            var controller = new DinnersController(_mockRepository.Object, _mockDateTime.Object);

            var result = controller.Rsvp(new RsvpRequest()) as HttpNotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal("Dinner not found.", (string)result.Value);
        }
    }
}