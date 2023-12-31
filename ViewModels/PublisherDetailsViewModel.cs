﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwShared.Services;

namespace PamiwMauiApp.ViewModels;

[QueryProperty(nameof(Publisher), nameof(Publisher))]
[QueryProperty(nameof(PublishersViewModel), nameof(PublishersViewModel))]
public partial class PublisherDetailsViewModel : BaseViewModel
{
    private readonly IPublisherService _publisherService;
    private readonly MauiMessageDialogService _dialogService;
    private PublishersViewModel _publishersViewModel;
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public PublisherDetailsViewModel(IPublisherService publisherService, PublishersViewModel publishersViewModel, MauiMessageDialogService dialogService, LocalizationResourceManager localizationResourceManager)
    {
        _publisherService = publisherService;
        _publishersViewModel = publishersViewModel;
        _dialogService = dialogService;
        this.localizationResourceManager = localizationResourceManager;
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

        var response = await _publisherService.UpdatePublisherAsync(Publisher.Id, publisherToUpdate);

        if (response.Success)
            await _publishersViewModel.GetPublishers();
        else
            _dialogService.ShowMessage(response.Message ?? "Failed to update publisher.");
    }


    [RelayCommand]
    public async Task Save()
    {
        IsBusy = true;

        await UpdatePublisher();

        IsBusy = false;

        await Shell.Current.GoToAsync("../", true);
    }

    [RelayCommand]
    public async Task Delete()
    {
        IsBusy = true;

        await DeletePublisher();

        IsBusy = false;

        await Shell.Current.GoToAsync("../", true);
    }
}
