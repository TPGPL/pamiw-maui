using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;
using PamiwMauiApp.Views;
using System.Collections.ObjectModel;

namespace PamiwMauiApp.ViewModels
{
    public partial class AuthorsViewModel : ObservableObject
    {
        private readonly IAuthorService _authorService;
        public ObservableCollection<Author> Authors { get; private set; }
        [ObservableProperty]
        private Author? selectedAuthor;

        public AuthorsViewModel(IAuthorService authorService)
        {
            _authorService = authorService;
            Authors = new ObservableCollection<Author>();
            GetAuthors();
        }

        public async Task GetAuthors()
        {
            Authors.Clear();

            var response = await _authorService.GetAuthorsAsync();

            if (response.Success && response.Data is not null)
            {
                foreach (var a in response.Data)
                {
                    Authors.Add(a);
                }
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Author author)
        {
            await Shell.Current.GoToAsync(nameof(AuthorDetailsView), true, new Dictionary<string, object>
            {
                {"Author", author },
                {nameof(AuthorsViewModel), this }
            });

            SelectedAuthor = author;
        }

        [RelayCommand]
        public async Task New()
        {
            SelectedAuthor = new Author();
            await Shell.Current.GoToAsync(nameof(AuthorDetailsView), true, new Dictionary<string, object>
            {
                {"Author", SelectedAuthor },
                {nameof(AuthorsViewModel), this }
            });
        }
    }
}
