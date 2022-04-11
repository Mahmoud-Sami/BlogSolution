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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullName.Text.Trim() == "" || txtUsername.Text.Trim() == "" || txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Fill all data", "Missing Data !", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User? user = DbCommands.userExist(txtUsername.Text);
            if (user == null)
            {
                DbCommands.UserRegister(txtFullName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Password.Trim());
                MessageBox.Show($"Welcome, {txtFullName.Text.Trim()}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("This username is taken, try another one", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
