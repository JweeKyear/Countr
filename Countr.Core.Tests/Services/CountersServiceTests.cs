using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Countr.Core.Repositories;
using Countr.Core.Services;
using Countr.Core.Models;
using MvvmCross.Plugin.Messenger;

namespace Countr.Core.Tests.Services
{
    [TestFixture]
    public class CountersServiceTests
    {
        ICountersService service;
        Mock<ICountersRepository> repo;
        Mock<IMvxMessenger> messenger;

        [SetUp]
        public void SetUP()
        {
            repo = new Mock<ICountersRepository>();
            messenger = new Mock<IMvxMessenger>();
            service = new CountersService(repo.Object, messenger.Object);
        }

        [Test]
        public async Task IncrementCounter_IncrementsTheCounter()
        {
            // Arrange
            var counter = new Counter { Count = 0 };
            // Act
            await service.IncrementCounter(counter);
            // Assert
            Assert.AreEqual(1, counter.Count);
        }

        [Test]
        public async Task IncrementCounter_SavesTheIncrementedCounter()
        {
            // Arrange
            var counter = new Counter { Count = 0 };
            // Act
            await service.IncrementCounter(counter);
            // Assert
            repo.Verify(r => r.Save(It.Is<Counter>(c => c.Count == 1)), Times.Once());
        }
        [Test]
        public async Task GetAllCounters_ReturnAllCountersFromTheRepository()
        {
            // Arrange
            var counters = new List<Counter>
            {
                new Counter {Name = "Counter1"},
                new Counter {Name = "Counter2"}
            };
            repo.Setup(r => r.GetAll()).ReturnsAsync(counters);
            // Act
            var result = await service.GetAllCounters();
            // Assert
            CollectionAssert.AreEqual(result, counters);
        }
        [Test]
        public async Task DeleteCounter_PublishesAMessage()
        {
            // Act
            await service.DeleteCounter(new Counter());
            // Assert
            messenger.Verify(m => m.Publish(It.IsAny<CountersChangedMessage>()));
        }
    }
}
