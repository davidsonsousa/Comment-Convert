using CommentConvert.Ui.Core;
using CommentConvert.Ui.Models;
using Newtonsoft.Json;
using System;
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
            string[] delimiter = { Environment.NewLine };

            foreach (var line in txtArticleUrls.Text.Split(delimiter, StringSplitOptions.None))
            {
                var fbComments = Utilities.LoadFacebookComments(line, txtToken.Text);

                if (fbComments.IsError)
                {
                    MessageBox.Show(fbComments.Result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var generate = Utilities.GenerateXmlComment(JsonConvert.DeserializeObject<FbComment>(fbComments.Result));

                if (!generate.IsError)
                {
                    MessageBox.Show(generate.Result, "Comment Convert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(generate.Result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
