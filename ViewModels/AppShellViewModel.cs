﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Views;
using System;
namespace PamiwMauiApp.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        private readonly UserInfo _userInfo;

        public AppShellViewModel(UserInfo userInfo)
        {
            _userInfo = userInfo;
        }

        [RelayCommand]
        public async Task SignOut()
        {
            _userInfo.Authenticated = false;
            _userInfo.Token = string.Empty;
            _userInfo.Username = string.Empty;

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}