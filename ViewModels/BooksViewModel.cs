using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;
using PamiwMauiApp.Views;
using System.Collections.ObjectModel;

namespace PamiwMauiApp.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {
        private readonly IBookService _bookService;
        private readonly MauiMessageDialogService _dialogService;
        public ObservableCollection<Book> Books { get; private set; }
        [ObservableProperty]
        private Book? selectedBook;

        public BooksViewModel(IBookService bookService, MauiMessageDialogService dialogService)
        {
            _bookService = bookService;
            _dialogService = dialogService;
            Books = new ObservableCollection<Book>();
            GetBooks();
        }

        public async Task GetBooks()
        {
            Books.Clear();

            var response = await _bookService.GetBooksAsync();

            if (response.Success && response.Data is not null)
            {
                foreach (var a in response.Data)
                {
                    Books.Add(a);
                }
            } else
            {
                _dialogService.ShowMessage(response.Message ?? "Failed to get books.");
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Book book)
        {
            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", book },
                {nameof(BooksViewModel), this }
            });

            SelectedBook = book;
        }

        [RelayCommand]
        public async Task New()
        {
            SelectedBook = new Book();
            await Shell.Current.GoToAsync(nameof(NewBookView), true, new Dictionary<string, object>
            {
                {"Book", SelectedBook },
                {nameof(BooksViewModel), this }
            });
        }
    }
}
