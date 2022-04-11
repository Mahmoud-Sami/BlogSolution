using BlogApp.Models;
using BlogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlogApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        BlogDbContext _dbContext;
        public LoginWindow(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
            InitializeComponent();
            this.DataContext = new LoginViewModel(_dbContext, this);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(_dbContext);
            registerWindow.Show();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((LoginViewModel)this.DataContext).Password = (sender as PasswordBox).Password;
        }
    }
}
