using AudioLibraryManager.Data;
using AudioLibraryManager.Model;
using AudioLibraryManager.Shared;
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

        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
