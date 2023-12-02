using CommunityToolkit.Mvvm.ComponentModel;
using PamiwMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamiwMauiApp.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserRegister user;
    }
}
