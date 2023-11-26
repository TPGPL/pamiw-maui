using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Author), nameof(Author))]
    [QueryProperty(nameof(AuthorsViewModel), nameof(AuthorsViewModel))]
    public partial class NewAuthorViewModel : ObservableObject
    {
        private readonly IAuthorService _authorService;
        private AuthorsViewModel _authorsViewModel;

        public NewAuthorViewModel(IAuthorService authorService, AuthorsViewModel authorsViewModel)
        {
            _authorService = authorService;
            _authorsViewModel = authorsViewModel;
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
        }

        [RelayCommand]
        public async Task Save()
        {

            await CreateAuthor();
            await Shell.Current.GoToAsync("../", true);

        }
    }
}
