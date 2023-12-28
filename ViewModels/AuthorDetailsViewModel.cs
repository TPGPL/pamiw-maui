using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwShared.Services;

namespace PamiwMauiApp.ViewModels;

[QueryProperty(nameof(Author), nameof(Author))]
[QueryProperty(nameof(AuthorsViewModel), nameof(AuthorsViewModel))]
public partial class AuthorDetailsViewModel : BaseViewModel
{
    private readonly IAuthorService _authorService;
    private readonly MauiMessageDialogService _dialogService;
    private AuthorsViewModel _authorsViewModel;
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;


    public AuthorDetailsViewModel(IAuthorService authorService, AuthorsViewModel authorsViewModel, MauiMessageDialogService dialogService, LocalizationResourceManager localizationResourceManager)
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

    public async Task DeleteAuthor()
    {
        await _authorService.DeleteAuthorAsync(Author.Id);
        await _authorsViewModel.GetAuthors();
    }

    public async Task UpdateAuthor()
    {
        var authorToUpdate = new Author()
        {
            Id = Author.Id,
            Name = Author.Name,
            Surname = Author.Surname,
            Email = Author.Email
        };

        var response = await _authorService.UpdateAuthorAsync(Author.Id, authorToUpdate);

        if (response.Success)
            await _authorsViewModel.GetAuthors();
        else
            _dialogService.ShowMessage(response.Message ?? "Failed to update author.");
    }


    [RelayCommand]
    public async Task Save()
    {
        await UpdateAuthor();
        await Shell.Current.GoToAsync("../", true);
    }

    [RelayCommand]
    public async Task Delete()
    {
        await DeleteAuthor();
        await Shell.Current.GoToAsync("../", true);
    }
}
