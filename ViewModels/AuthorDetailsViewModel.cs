﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels
{
    [QueryProperty(nameof(Author), nameof(Author))]
    [QueryProperty(nameof(AuthorsViewModel), nameof(AuthorsViewModel))]
    public partial class AuthorDetailsViewModel : ObservableObject
    {
        private readonly IAuthorService _authorService;
        private AuthorsViewModel _authorsViewModel;

        public AuthorDetailsViewModel(IAuthorService authorService, AuthorsViewModel authorsViewModel)
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

            await _authorService.UpdateAuthorAsync(Author.Id, authorToUpdate);
            await _authorsViewModel.GetAuthors();
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
}
