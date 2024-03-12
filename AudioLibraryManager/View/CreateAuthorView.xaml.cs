using AudioLibraryManager.Model;
using System;
using System.Windows;

namespace AudioLibraryManager.View
{
    public partial class CreateAuthorView : Window
    {
        public Author NewAuthor { get; set; }
        public CreateAuthorView()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(AuthorTextBox.Text))
                {
                    throw new Exception("Name of author must be given");
                }

                if (string.IsNullOrEmpty(CountryTextBox.Text))
                {
                    throw new Exception("Country of author must be given");
                }

                NewAuthor = new Author
                {
                    Name = AuthorTextBox.Text,
                    Country = CountryTextBox.Text,
                };
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
