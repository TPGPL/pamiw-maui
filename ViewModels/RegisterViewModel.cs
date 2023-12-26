﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Services;
using PamiwMauiApp.Components;
using PamiwShared.Models;

namespace PamiwMauiApp.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly MauiMessageDialogService _messageDialogService;
    private readonly IAuthService _authService;

    [ObservableProperty]
    UserRegister user = new UserRegister();

    public RegisterViewModel(MauiMessageDialogService messageDialogService, IAuthService authService)
    {
        _messageDialogService = messageDialogService;
        _authService = authService;
    }

    [RelayCommand]
    public async Task Register()
    {
        var newUser = new UserRegister()
        {
            Username = User.Username,
            Email = User.Email,
            Password = User.Password
        };

        var response = await _authService.RegisterAsync(newUser);

        if (response.Message is not null && response.Message.Any())
        {
            _messageDialogService.ShowMessage(response.Message);
        }

        if (response.Success)
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
