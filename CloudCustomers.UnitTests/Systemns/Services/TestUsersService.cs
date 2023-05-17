

using CloudCustomers.Domain.Domain;
using CloudCustomers.Services.Services;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace CloudCustomers.UnitTests.Systemns.Services;

public class TestUsersService
{
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesHttpRequest()
    {
        //Arrange
        var expectedResponse = UserFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UserService(httpClient);

        //Act  
        var users = await sut.ListUsers();

        //Assert  
        //Verify HTTP request was made
        handlerMock
            .Protected()
            .Verify(
            "SendAsync",
            Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
             ItExpr.IsAny<CancellationToken> ()
            );
    }

    [Fact]
    public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
    {
        //Arrange
        var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UserService(httpClient);

        //Act  
        var result = await sut.ListUsers();

        //Assert  
        //Verify HTTP request was made
        result.Count().Should().Be(0); 
    }

    [Fact]
    public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
    {
        //Arrange
        var expectedResponse = UserFixture.GetTestUsers();
        var handleMock = MockHttpMessageHandler<User>
            .SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handleMock.Object);
        var sut = new UserService(httpClient);

        //Act  
        var result = await sut.ListUsers();

        //Assert  
        //Verify HTTP request was made
        result.Count().Should().Be(expectedResponse.Count);
    }

     

}
