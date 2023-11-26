using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Publisher), nameof(Publisher))]
    [QueryProperty(nameof(PublishersViewModel), nameof(PublishersViewModel))]
    public partial class NewPublisherViewModel : ObservableObject
    {
        private readonly IPublisherService _publisherService;
        private readonly MauiMessageDialogService _dialogService;
        private PublishersViewModel _publishersViewModel;

        public NewPublisherViewModel(IPublisherService publisherService, PublishersViewModel publishersViewModel, MauiMessageDialogService dialogService)
        {
            _publisherService = publisherService;
            _publishersViewModel = publishersViewModel;
            _dialogService = dialogService;
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
            else
                _dialogService.ShowMessage(result.Message ?? "Failed to create publisher.");
        }

        [RelayCommand]
        public async Task Save()
        {

            await CreatePublisher();
            await Shell.Current.GoToAsync("../", true);

        }
    }
}
