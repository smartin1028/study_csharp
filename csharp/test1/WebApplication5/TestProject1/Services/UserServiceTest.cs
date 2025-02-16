using System;
using Moq;
using NUnit.Framework;
using TestProject1.unitTest;

namespace TestProject1.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void UserTest01()
        {
            Console.WriteLine("test");

            // 목 객체 생성
            var mockRepo = new Mock<IUserRepository>();

            // 목 설정
            mockRepo.Setup(repo => repo.GetById(1))
                .Returns(new User { Id = 1, Name = "Test User" });

            // 목 객체 사용
            var userRepo = mockRepo.Object;
            var user = userRepo.GetById(1);
            
            Assert.AreEqual(user.Id, 2);
        }
    }
}