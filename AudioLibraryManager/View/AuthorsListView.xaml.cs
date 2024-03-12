using AudioLibraryManager.Data;
using AudioLibraryManager.Model;
using AudioLibraryManager.Shared;
using AudioLibraryManager.Shared.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AudioLibraryManager.View
{
    public partial class AuthorsListView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Author> _authors;

        public event EventHandler<AuthorDeletedEventArgs> AuthorDeleted;
        public event EventHandler<AuthorUpdatedEventArgs> AuthorUpdated;

        public ObservableCollection<Author> Authors 
        { 
            get { return _authors; }
            set
            {
                if (_authors != value)
                {
                    _authors = value;
                    OnPropertyChanged(nameof(Authors));
                }
            }
        }

        public AuthorsListView()
        {
            AuthorRepository.Initialize(JsonUtils.GetAuthorsJson());

            InitializeComponent();
            updateData();
            DataContext = this;
        }

        private void updateData()
        {
            Authors = new ObservableCollection<Author>(AuthorRepository.Instance.GetAll());
        }

        private void CreateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var createAuthorView = new CreateAuthorView();
            createAuthorView.ShowDialog();
            if (createAuthorView.NewAuthor != null)
            {
                AuthorRepository.Instance.Add(createAuthorView.NewAuthor);
                updateData();
            }
        }

        private void UpdateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = AuthorDataGrid.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select author to delete");
                return;
            }

            var updatedAuthor = (Author) selectedItem;

            var updateAuthorView = new UpdateAuthorView(updatedAuthor);
            updateAuthorView.ShowDialog();

            AuthorRepository.Instance.Update(updatedAuthor, updateAuthorView.UpdatedAuthor);

            TrackRepository.UpdateAllByAuthor(updateAuthorView.UpdatedAuthor);
            
            AuthorUpdated?.Invoke(this, new AuthorUpdatedEventArgs());
            updateData();
        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = AuthorDataGrid.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select author to delete");
                return;
            }

            var result = MessageBox.Show(
                "Are you sure you want to delete this author? All tracks this genre will be automaticaly deleted!",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            var deletedAuthor = (Author) selectedItem;

            AuthorRepository.Instance.Delete(deletedAuthor);

            TrackRepository.DeleteAllByAuthor(deletedAuthor);
            AuthorDeleted?.Invoke(this, new AuthorDeletedEventArgs());

            updateData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
