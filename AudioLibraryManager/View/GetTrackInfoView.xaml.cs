using AudioLibraryManager.Model;
using System.Windows;

namespace AudioLibraryManager.View
{
    public partial class GetTrackInfoView : Window
    {
       
        public Track Track { get; set; }

        public GetTrackInfoView(Track track)
        {
            InitializeComponent();

            Track = track;
            Title = $"{Track.Author.Name} : {Track.Name}";

            IdField.Text = Track.Id ;
            NameField.Text = Track.Name;
            AuthorField.Text = Track.Author.Name;
            CountryField.Text = Track.Author.Country;
            DurationField.Text = Track.Duration.ToString("mm:ss");
            ReleaseDateField.Text = Track.ReleaseDate.ToString("dd MMMM. yyyy");
            GenreField.Text = Track.Genre.Name;
        }

        private void OkBtn_Click(object sender,  RoutedEventArgs e)
        {
            Close();
        }
    }
}
