using AudioLibraryManager.Data;
using AudioLibraryManager.Model;
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
            GenreRepository.Initialize(new List<Genre>());
            InitializeComponent();
            UpdateData();
            DataContext = this;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var createGenreView = new CreateGenreView();
            createGenreView.ShowDialog();
            if (createGenreView.NewGenre != null)
            {
                GenreRepository.Instance.Add(createGenreView.NewGenre);
                UpdateData();
            }
        }

        private void UpdateData()
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
