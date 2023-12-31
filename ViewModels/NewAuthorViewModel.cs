using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwShared.Services;

namespace PamiwMauiApp.ViewModels;

[QueryProperty(nameof(Author), nameof(Author))]
[QueryProperty(nameof(AuthorsViewModel), nameof(AuthorsViewModel))]
public partial class NewAuthorViewModel : BaseViewModel
{
    private readonly IAuthorService _authorService;
    private readonly MauiMessageDialogService _dialogService;
    private AuthorsViewModel _authorsViewModel;
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public NewAuthorViewModel(IAuthorService authorService, AuthorsViewModel authorsViewModel, MauiMessageDialogService dialogService, LocalizationResourceManager localizationResourceManager)
    {
        _authorService = authorService;
        _authorsViewModel = authorsViewModel;
        _dialogService = dialogService;
        this.localizationResourceManager = localizationResourceManager;
    }

    public AuthorsViewModel AuthorsViewModel
    {
        get
        {
            return _authorsViewModel;
        }
        set
        {
            _authorsViewModel = value;
        }
    }


    [ObservableProperty]
    Author author;


    public async Task CreateAuthor()
    {
        var newAuthor = new Author()
        {
            Name = Author.Name,
            Surname = Author.Surname,
            Email = Author.Email
        };

        var result = await _authorService.CreateAuthorAsync(newAuthor);

        if (result.Success)
            await _authorsViewModel.GetAuthors();
        else
            _dialogService.ShowMessage(result.Message ?? "Failed to create author.");
    }

    [RelayCommand]
    public async Task Save()
    {
        IsBusy = true;

        await CreateAuthor();

        IsBusy = false;

        await Shell.Current.GoToAsync("../", true);

    }
}
