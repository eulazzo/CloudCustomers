using CloudCustomers.API.Controllers;
using CloudCustomers.Domain.Domain;
using CloudCustomers.Services.Interfaces;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests.Systemns.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200Async()
    {

        //arrange
        var mockUsersService = new Mock<IUserService>();

        var sut = new UsersController(mockUsersService.Object);
        mockUsersService.
        Setup(service => service.ListUsers())
        .ReturnsAsync(UserFixture.GetTestUsers());

        //Act
        var result = (ObjectResult)await sut.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactOnce()
    {
        //arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService.
            Setup(service => service.ListUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());

        var sut = new UsersController(mockUsersService.Object);

        //Act
        var result = (ObjectResult)await sut.Get();

        //Assert
        mockUsersService.Verify(service => service.ListUsers(), Times.Once());

    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUsers()
    {

        //arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService.
            Setup(service => service.ListUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());

        var sut = new UsersController(mockUsersService.Object);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }



    [Fact]
    public async Task Get_OnNoUserFound_Returns404()
    {

        //arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService.
            Setup(service => service.ListUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object);

        //Act
        var result = (NotFoundResult)await sut.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

}