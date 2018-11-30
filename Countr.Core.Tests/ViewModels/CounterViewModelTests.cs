using System.Threading.Tasks;
using NUnit.Framework;
using Countr.Core.ViewModels;
using Countr.Core.Models;
using Moq;
using Countr.Core.Services;
using MvvmCross.Navigation;

namespace Countr.Core.Tests.ViewModels
{
    [TestFixture]
    public class CounterViewModelTests
    {
        CounterViewModel viewModel;
        Mock<ICountersService> countersService;
        Mock<IMvxNavigationService> navigationService;

        [SetUp]
        public void SetUp()
        {
            countersService = new Mock<ICountersService>();
            navigationService = new Mock<IMvxNavigationService>();

            viewModel = new CounterViewModel(countersService.Object, navigationService.Object);
            viewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);
        }

        [Test]
        public async Task IncrementCounter_IncrementsTheCounter()
        {
            // Act
            await viewModel.IncrementCommand.ExecuteAsync();
            // Assert
            countersService.Verify(s => s.IncrementCounter(It.IsAny<Counter>()));
        }

        [Test]
        public async Task IncrementCounter_RaisesPropertyChanged()
        {
            // Arrange
            var propertyChangedRaised = false;
            viewModel.PropertyChanged +=
                (s, e) => propertyChangedRaised = (e.PropertyName == "Count");
            // Act
            await viewModel.IncrementCommand.ExecuteAsync();
            // Assert
            Assert.IsTrue(propertyChangedRaised);
        }

        [Test]
        public void Name_ComesFromCounter()
        {
            // Arrange
            var counter = new Counter { Name = "A Counter" };
            // Act
            viewModel.Prepare(counter);
            // Assert
            Assert.AreEqual(counter.Name, viewModel.Name);
        }
        [Test]
        public void Count_ComesFromCounter()
        {
            // Arrange
            var counter = new Counter { Count = 0 };
            // Act
            viewModel.Prepare(counter);
            // Assert
            Assert.AreEqual(counter.Count, viewModel.Count);
        }

        //[Test]
        //public async Task SaveCommand_SavesTheCounter()
        //{
        //    // Arrange
        //    var counter = new Counter { Name = "A Counter" };
        //    viewModel.Prepare(counter);
        //    // Act
        //    await viewModel.SaveCommand.ExecuteAsync();
        //    // Assert
        //    countersService.Verify(c => c.AddNewCounter("A Counter"));
        //    navigationService.Verify(n => n.Close(viewModel));
        //}

        //[Test]
        //public void CancelCommand_DoesntSaveTheCounter()
        //{
        //    // Arrange
        //    var counter = new Counter { Name = "A Counter" };
        //    viewModel.Prepare(counter);
        //    // Act
        //    viewModel.CancelCommand.Execute();
        //    // Assert
        //    countersService.Verify(c => c.AddNewCounter(It.IsAny<string>()), Times.Never());
        //    navigationService.Verify(n => n.Close(viewModel));
        //}
    }
}
