using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Publisher), nameof(Publisher))]
    [QueryProperty(nameof(PublishersViewModel), nameof(PublishersViewModel))]
    public partial class NewPublisherViewModel : ObservableObject
    {
        private readonly IPublisherService _publisherService;
        private PublishersViewModel _publishersViewModel;

        public NewPublisherViewModel(IPublisherService publisherService, PublishersViewModel publishersViewModel)
        {
            _publisherService = publisherService;
            _publishersViewModel = publishersViewModel;
        }

        public PublishersViewModel PublishersViewModel
        {
            get
            {
                return _publishersViewModel;
            }
            set
            {
                _publishersViewModel = value;
            }
        }


        [ObservableProperty]
        Publisher publisher;


        public async Task CreatePublisher()
        {
            var newPublisher = new Publisher()
            {
                Name = Publisher.Name
            };

            var result = await _publisherService.CreatePublisherAsync(newPublisher);

            if (result.Success)
                await _publishersViewModel.GetPublishers();
        }

        [RelayCommand]
        public async Task Save()
        {

            await CreatePublisher();
            await Shell.Current.GoToAsync("../", true);

        }
    }
}
