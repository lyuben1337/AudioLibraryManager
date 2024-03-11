using AudioLibraryManager.Data;
using AudioLibraryManager.Model;
using AudioLibraryManager.Shared;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AudioLibraryManager.View
{
    public partial class TracksListView : UserControl
    {
        public List<Track> Tracks { get; set; }
        public TracksListView()
        {
            TrackRepository.Initialize(new List<Track>());
            InitializeComponent();
            Tracks = TrackRepository.Instance.GetAll();
            DataContext = this;
        }

        private void CreateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var CreateTrackWindow = new CreateTrackView();
            CreateTrackWindow.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
