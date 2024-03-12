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
    public partial class GenresListView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Genre> _genres;

        public event EventHandler<GenreDeletedEventArgs> GenreDeleted;

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set
            {
                if (_genres != value)
                {
                    _genres = value;
                    OnPropertyChanged(nameof(Genres));
                }
            }
        }

        public GenresListView()
        {
            GenreRepository.Initialize(JsonUtils.GetGenresJson());

            InitializeComponent();
            updateData();
            DataContext = this;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var createGenreView = new CreateGenreView();
            createGenreView.ShowDialog();
            if (createGenreView.NewGenre != null)
            {
                GenreRepository.Instance.Add(createGenreView.NewGenre);
                updateData();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = GenreDataGrid.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select genre to delete");
                return;
            }

            var deletedGenre = (Genre) selectedItem;
            var result = MessageBox.Show(
                "Are you sure you want to delete this genre? All tracks this genre will be automaticaly deleted!",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            GenreRepository.Instance.Delete(deletedGenre);

            TrackRepository.DeleteAllByGenre(deletedGenre);
            GenreDeleted?.Invoke(this, new GenreDeletedEventArgs());

            updateData();
        }

        private void updateData()
        {
            Genres = new ObservableCollection<Genre>(GenreRepository.Instance.GetAll());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
