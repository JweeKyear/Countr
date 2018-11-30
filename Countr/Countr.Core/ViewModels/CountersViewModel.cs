

using Countr.Core.Models;
using Countr.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Countr.Core.ViewModels
{
    public class CountersViewModel : MvxViewModel
    {
        readonly ICountersService service;
        readonly MvxSubscriptionToken token;
        readonly IMvxNavigationService navigationService;

        public CountersViewModel(ICountersService service, IMvxMessenger messenger, IMvxNavigationService navigationService)
        {
            token = messenger.SubscribeOnMainThread<CountersChangedMessage> (async m => await LoadCounters());
            this.service = service;
            Counters = new ObservableCollection<CounterViewModel>();
            this.navigationService = navigationService;
            ShowAddNewCounterCommand = new MvxAsyncCommand(ShowAddNewCounter);
        }

        public IMvxAsyncCommand ShowAddNewCounterCommand { get; }

        async Task ShowAddNewCounter()
        {
            await navigationService.Navigate(typeof(CounterViewModel), new Counter());
        }

        public ObservableCollection<CounterViewModel> Counters { get; }

        public override async Task Initialize()
        {
            await LoadCounters().ConfigureAwait(false);
        }

        public async Task LoadCounters()
        {
            Counters.Clear();
            var counters = await service.GetAllCounters().ConfigureAwait(false);
            foreach (var counter in counters)
            {
                var viewModel = new CounterViewModel(service, navigationService);
                viewModel.Prepare(counter);
                Counters.Add(viewModel);
            }
        }
    }
}
