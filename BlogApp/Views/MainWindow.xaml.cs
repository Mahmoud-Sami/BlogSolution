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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User currentUser;
        public MainWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            tbFullName.Text = currentUser.FullName;
            this.DataContext = currentUser;

            TextBox test = new TextBox();
            test.Text = "Line 2";
            spPostView.Children.Add(test);
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text.Trim() == "" || txtBody.Text.Trim() == "")
            {
                MessageBox.Show("Title & Body missing", "Missing Data !", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DbCommands.Post(txtTitle.Text, txtBody.Text, currentUser);
            MessageBox.Show("Post Published ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullNameEdit.Text.Trim() == "" || txtUsernameEdit.Text.Trim() == "")
            {
                MessageBox.Show("Fill all data", "Missing Data !", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DbCommands.UserEdit(currentUser, txtFullNameEdit.Text.Trim(), txtPasswordEdit.Password.Trim());
            tbFullName.Text = txtFullNameEdit.Text;
            txtPasswordEdit.Password = "";
            MessageBox.Show($"Data Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
    }
}
