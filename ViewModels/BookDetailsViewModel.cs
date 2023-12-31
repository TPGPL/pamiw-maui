using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwShared.Services;

namespace PamiwMauiApp.ViewModels;

[QueryProperty(nameof(Book), nameof(Book))]
[QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
public partial class BookDetailsViewModel : BaseViewModel
{
    private readonly IBookService _bookService;
    private readonly MauiMessageDialogService _dialogService;
    private BooksViewModel _booksViewModel;
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public BookDetailsViewModel(IBookService bookService, BooksViewModel booksViewModel, MauiMessageDialogService dialogService, LocalizationResourceManager localizationResourceManager)
    {
        _bookService = bookService;
        _booksViewModel = booksViewModel;
        _dialogService = dialogService;
        this.localizationResourceManager = localizationResourceManager;
    }

    public BooksViewModel BooksViewModel
    {
        get
        {
            return _booksViewModel;
        }
        set
        {
            _booksViewModel = value;
        }
    }


    [ObservableProperty]
    Book book;

    public async Task DeleteBook()
    {
        await _bookService.DeleteBookAsync(Book.Id);
        await _booksViewModel.GetBooks();
    }

    public async Task UpdateBook()
    {
        var bookToUpdate = new Book()
        {
            Id = Book.Id,
            Title = Book.Title,
            AuthorID = Book.AuthorID,
            PublisherID = Book.PublisherID,
            PageCount = Book.PageCount,
            ReleaseDate = Book.ReleaseDate,
            ISBN = Book.ISBN
        };

        var response = await _bookService.UpdateBookAsync(Book.Id, bookToUpdate);

        if (response.Success)
            await _booksViewModel.GetBooks();
        else
            _dialogService.ShowMessage(response.Message ?? "Failed to update book.");
    }


    [RelayCommand]
    public async Task Save()
    {
        IsBusy = true;
        
        await UpdateBook();
        
        IsBusy = false;
        
        await Shell.Current.GoToAsync("../", true);
    }

    [RelayCommand]
    public async Task Delete()
    {
        IsBusy = true;

        await DeleteBook();
        
        IsBusy = false;
        
        await Shell.Current.GoToAsync("../", true);
    }
}
