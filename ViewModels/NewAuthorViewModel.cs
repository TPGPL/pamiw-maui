using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels;

[QueryProperty(nameof(Author), nameof(Author))]
[QueryProperty(nameof(AuthorsViewModel), nameof(AuthorsViewModel))]
public partial class NewAuthorViewModel : ObservableObject
{
    private readonly IAuthorService _authorService;
    private readonly MauiMessageDialogService _dialogService;
    private AuthorsViewModel _authorsViewModel;

    public NewAuthorViewModel(IAuthorService authorService, AuthorsViewModel authorsViewModel, MauiMessageDialogService dialogService)
    {
        _authorService = authorService;
        _authorsViewModel = authorsViewModel;
        _dialogService = dialogService;
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

        await CreateAuthor();
        await Shell.Current.GoToAsync("../", true);

    }
}
