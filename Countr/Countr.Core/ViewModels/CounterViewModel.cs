using Countr.Core.Models;
using Countr.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Countr.Core.ViewModels
{
    public class CounterViewModel : MvxViewModel<Counter>
    {
        Counter counter;

        public override void Prepare(Counter counter)
        {
            this.counter = counter;
        }

        public string Name
        {
            get { return counter.Name; }
            set
            {
                if (Name == value) return;
                counter.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Count => counter.Count;

        readonly ICountersService service;
        readonly IMvxNavigationService navigationService;

        public CounterViewModel(ICountersService service, IMvxNavigationService navigationService)
        {
            this.service = service;
            this.navigationService = navigationService;

            IncrementCommand = new MvxAsyncCommand(IncrementCounter);
            DeleteCommand = new MvxAsyncCommand(DeleteCounter);
            CancelCommand = new MvxAsyncCommand(Cancel);
            SaveCommand = new MvxAsyncCommand(Save);
        }

        public IMvxAsyncCommand IncrementCommand { get; }
        public IMvxAsyncCommand DeleteCommand { get; }
        public IMvxAsyncCommand CancelCommand { get; }
        public IMvxAsyncCommand SaveCommand { get; }

        async Task IncrementCounter()
        {
            await service.IncrementCounter(counter);
            RaisePropertyChanged(() => Count);
        }

        async Task DeleteCounter()
        {
            await service.DeleteCounter(counter);
        }

        async Task Cancel()
        {
            await navigationService.Close(this);
        }

        async Task Save()
        {
            await service.AddNewCounter(counter.Name);
            await navigationService.Close(this);
        }
    }
}
