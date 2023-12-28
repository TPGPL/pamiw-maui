﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwShared.Services;

namespace PamiwMauiApp.ViewModels;

[QueryProperty(nameof(Book), nameof(Book))]
[QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
public partial class NewBookViewModel : BaseViewModel
{
    private readonly IBookService _bookService;
    private readonly MauiMessageDialogService _dialogService;
    private BooksViewModel _booksViewModel;
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public NewBookViewModel(IBookService bookService, BooksViewModel booksViewModel, MauiMessageDialogService dialogService, LocalizationResourceManager localizationResourceManager)
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


    public async Task CreateBook()
    {
        var newBook = new Book()
        {
            Title = Book.Title,
            AuthorID = Book.AuthorID,
            PublisherID = Book.PublisherID,
            PageCount = Book.PageCount,
            ReleaseDate = Book.ReleaseDate,
            ISBN = Book.ISBN
        };

        var result = await _bookService.CreateBookAsync(newBook);

        if (result.Success)
            await _booksViewModel.GetBooks();
        else
            _dialogService.ShowMessage(result.Message ?? "Failed to create book.");
    }

    [RelayCommand]
    public async Task Save()
    {

        await CreateBook();
        await Shell.Current.GoToAsync("../", true);

    }
}
