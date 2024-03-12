using AudioLibraryManager.Model;
using System;
using System.Windows;

namespace AudioLibraryManager.View
{
    public partial class UpdateAuthorView : Window
    {
        public Author UpdatedAuthor { get; set; }

        public UpdateAuthorView(Author updatedAuthor)
        {
            InitializeComponent();
            UpdatedAuthor = updatedAuthor;

            AuthorTextBox.Text = UpdatedAuthor.Name;
            CountryTextBox.Text = UpdatedAuthor.Country;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
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

                UpdatedAuthor.Name = AuthorTextBox.Text;
                UpdatedAuthor.Country = CountryTextBox.Text;

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
