using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
    public partial class NewBookViewModel : ObservableObject
    {
        private readonly IBookService _bookService;
        private BooksViewModel _booksViewModel;

        public NewBookViewModel(IBookService bookService, BooksViewModel booksViewModel)
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
        }

        [RelayCommand]
        public async Task Save()
        {

            await CreateBook();
            await Shell.Current.GoToAsync("../", true);

        }
    }
}
