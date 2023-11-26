﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;
using PamiwMauiApp.Views;
using System.Collections.ObjectModel;

namespace PamiwMauiApp.ViewModels
{
    public partial class PublishersViewModel : ObservableObject
    {
        private readonly IPublisherService _publisherService;
        private readonly MauiMessageDialogService _dialogService;
        public ObservableCollection<Publisher> Publishers { get; private set; }
        [ObservableProperty]
        private Publisher? selectedPublisher;

        public PublishersViewModel(IPublisherService publisherService, MauiMessageDialogService dialogService)
        {
            _publisherService = publisherService;
            _dialogService = dialogService;
            Publishers = new ObservableCollection<Publisher>();
            GetPublishers();
        }

        public async Task GetPublishers()
        {
            Publishers.Clear();

            var response = await _publisherService.GetPublishersAsync();

            if (response.Success && response.Data is not null)
            {
                foreach (var a in response.Data)
                {
                    Publishers.Add(a);
                }
            } else
            {
                _dialogService.ShowMessage(response.Message ?? "Failed to get publishers.");
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Publisher publisher)
        {
            await Shell.Current.GoToAsync(nameof(PublisherDetailsView), true, new Dictionary<string, object>
            {
                {"Publisher", publisher },
                {nameof(PublishersViewModel), this }
            });

            SelectedPublisher = publisher;
        }

        [RelayCommand]
        public async Task New()
        {
            SelectedPublisher = new Publisher();
            await Shell.Current.GoToAsync(nameof(NewPublisherView), true, new Dictionary<string, object>
            {
                {"Publisher", SelectedPublisher },
                {nameof(PublishersViewModel), this }
            });
        }
    }
}
