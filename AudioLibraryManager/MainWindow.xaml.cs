using AudioLibraryManager.Data;
using AudioLibraryManager.Shared;
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

namespace AudioLibraryManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GenresListView.GenreDeleted += TracksListView.OnGenreDeleted;
            AuthorsListView.AuthorDeleted += TracksListView.OnAuthorDeleted;
            AuthorsListView.AuthorUpdated += TracksListView.OnAuthorUpdated;

            Closed += OnMainWindowClosed;
        }

        private void OnMainWindowClosed(object? sender, EventArgs e)
        {
            JsonUtils.SaveAuthorsJson(AuthorRepository.Instance.ToJson());
            JsonUtils.SaveGenresJson(GenreRepository.Instance.ToJson());
            JsonUtils.SaveTracksJson(TrackRepository.Instance.ToJson());
        }
    }
}
