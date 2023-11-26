using CommunityToolkit.Mvvm.ComponentModel;
using PamiwMauiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamiwMauiApp.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {
        private readonly IBookService _bookService;

        public BooksViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}
