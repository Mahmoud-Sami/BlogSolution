using BlogApp.Models;
using BlogApp.ViewModels;
using BlogApp.Views.UserControls;
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

            tcSample.SelectedIndex = 0;
            UpdateHome();
            
        }

        private void UpdateHome()
        {
            spPostView.Children.Clear();
            using (var db = new BlogDbContext())
            {
                List<Post> posts = db.posts.ToList().OrderByDescending(o => o.PublishDate).ToList();
                foreach (var post in posts)
                {
                    PostViewUC postView = new PostViewUC();
                    postView.Title = post.Title;
                    postView.Body = post.Body;
                    postView.Author = db.users.Find(post.userID).FullName;
                    postView.Date = post.PublishDate.ToString("dddd, dd MMMM yyyy");
                    spPostView.Children.Add(postView);
                }
            }
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
            UpdateHome();
            tcSample.SelectedIndex = 0;
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            tcSample.SelectedIndex = 0;

        }
        private void btnCreateNewPost_Click(object sender, RoutedEventArgs e)
        {
            tcSample.SelectedIndex = 1;
            txtTitle.Text = "";
            txtBody.Text = "";
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            tcSample.SelectedIndex = 2;

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        
    }
}
