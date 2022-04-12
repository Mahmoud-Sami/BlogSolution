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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlogApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PostViewUC.xaml
    /// </summary>
    public partial class PostViewUC : UserControl
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }

        public PostViewUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }


    }


}
