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
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }

        

        private void Login()
        {
            if (txtUasername.Text.Trim() == "" || txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Enter the username & password", "Missing Data !", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
             
            User? currentUser = DbCommands.userExist(txtUasername.Text.Trim());
            if (currentUser != null && currentUser.Password == txtPassword.Password.Trim())
            {
                new MainWindow(currentUser).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong data");
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }
    }
}
