using Authorization_service;
using Authorization_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Authorization.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsTokenNotNullIsTokenNotNull_When_ValidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            var TokenObj = new TokenController(config.Object);
            var Result = TokenObj.AuthenticateUser(new Authenticate() { Name = "himanshu", Password = "chauhan" });
            Assert.IsNotNull(Result);
        }

        [Test]
        public void IsTokenNull_When_InvalidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            var TokenObj = new TokenController(config.Object);
            var Result =TokenObj.AuthenticateUser(new Authenticate(){Name = "wronginput",Password = "wronginput"});
            Assert.IsNull(Result);
        }

    }
}