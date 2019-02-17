using CommentConvert.Ui.Core;
using CommentConvert.Ui.Models;
using Newtonsoft.Json;
using System.Windows;

namespace CommentConvert.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnProcessComments.Click += BtnProcessComments_Click;
        }

        private void BtnProcessComments_Click(object sender, RoutedEventArgs e)
        {
            var (IsError, Result) = Utilities.LoadFacebookComments(txtArticleUrls.Text, txtToken.Text);

            if (IsError)
            {
                MessageBox.Show(Result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var fbComment = JsonConvert.DeserializeObject<FbComment>(Result);
        }
    }
}
