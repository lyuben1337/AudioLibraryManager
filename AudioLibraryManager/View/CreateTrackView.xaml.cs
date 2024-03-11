using AudioLibraryManager.Model;
using System.Windows;

namespace AudioLibraryManager.View
{
    /// <summary>
    /// Interaction logic for CreateTrackView.xaml
    /// </summary>
    public partial class CreateTrackView : Window
    {
        public Track newTrack { get; set; }
        public CreateTrackView()
        {
            
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
