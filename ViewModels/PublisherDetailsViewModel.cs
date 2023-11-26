using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Publisher), nameof(Publisher))]
    [QueryProperty(nameof(PublishersViewModel), nameof(PublishersViewModel))]
    public partial class PublisherDetailsViewModel : ObservableObject
    {
        private readonly IPublisherService _publisherService;
        private PublishersViewModel _publishersViewModel;

        public PublisherDetailsViewModel(IPublisherService publisherService, PublishersViewModel publishersViewModel)
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

        public async Task DeletePublisher()
        {
            await _publisherService.DeletePublisherAsync(Publisher.Id);
            await _publishersViewModel.GetPublishers();
        }

        public async Task UpdatePublisher()
        {
            var publisherToUpdate = new Publisher()
            {
                Id = Publisher.Id,
                Name = Publisher.Name
            };

            await _publisherService.UpdatePublisherAsync(Publisher.Id, publisherToUpdate);
            await _publishersViewModel.GetPublishers();
        }


        [RelayCommand]
        public async Task Save()
        {
            await UpdatePublisher();
            await Shell.Current.GoToAsync("../", true);
        }

        [RelayCommand]
        public async Task Delete()
        {
            await DeletePublisher();
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
