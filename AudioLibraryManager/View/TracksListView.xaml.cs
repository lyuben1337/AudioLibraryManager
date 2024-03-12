using AudioLibraryManager.Data;
using AudioLibraryManager.Model;
using AudioLibraryManager.Shared;
using AudioLibraryManager.Shared.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AudioLibraryManager.View
{
    public partial class TracksListView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Track> _tracks;
        public ObservableCollection<Track> Tracks {  
            get { return _tracks; }
            set
            {
                if (_tracks != value)
                {
                    _tracks = value;
                    OnPropertyChanged(nameof(Tracks));
                }
            }
        }

        public TracksListView()
        {
            TrackRepository.Initialize(JsonUtils.GetTracksJson());

            InitializeComponent();
            updateData();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void CreateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var createTrackWindow = new CreateTrackView();
            createTrackWindow.ShowDialog();
            if (createTrackWindow.NewTrack != null)
            {
                TrackRepository.Instance.Add(createTrackWindow.NewTrack);
                updateData();
            }
        }

        private void UpdateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selectedItem = TrackDataGrid.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select track to update");
                return;
            }

            var updatedTrack = (Track) TrackDataGrid.SelectedItem;
            var updateTrackWindow = new UpdateTrackView(updatedTrack);
            updateTrackWindow.ShowDialog();
            TrackRepository.Instance.Update(updatedTrack, updateTrackWindow.UpdatedTrack);
            updateData();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TrackDataGrid.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select track to delete");
                return;
            }

            var deletedTrack = (Track) TrackDataGrid.SelectedItem;
            var result = MessageBox.Show(
                "Are you sure you want to delete this track?", 
                "Confirmation", 
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No) {
                return;
            }

            TrackRepository.Instance.Delete(deletedTrack);
            updateData();
        }

        private void GetInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TrackDataGrid.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select track to get info");
                return;
            }

            new GetTrackInfoView((Track) selectedItem).ShowDialog();
        }

        private void updateData()
        {
            Tracks = new ObservableCollection<Track>(TrackRepository.Instance.GetAll());
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnGenreDeleted(object sender, GenreDeletedEventArgs e)
        {
            updateData();
        }

        public void OnAuthorDeleted(object sender, AuthorDeletedEventArgs e)
        {
            updateData();
        }

        public void OnAuthorUpdated(object sender, AuthorUpdatedEventArgs e)
        {
            updateData();
        }
    }
}
