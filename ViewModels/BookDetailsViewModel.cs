using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
    public partial class BookDetailsViewModel : ObservableObject
    {
        private readonly IBookService _bookService;
        private BooksViewModel _booksViewModel;

        public BookDetailsViewModel(IBookService bookService, BooksViewModel booksViewModel)
        {
            _bookService = bookService;
            _booksViewModel = booksViewModel;
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

            await _bookService.UpdateBookAsync(Book.Id, bookToUpdate);
            await _booksViewModel.GetBooks();
        }


        [RelayCommand]
        public async Task Save()
        {
            await UpdateBook();
            await Shell.Current.GoToAsync("../", true);
        }

        [RelayCommand]
        public async Task Delete()
        {
            await DeleteBook();
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
