﻿using AudioLibraryManager.Data;
using AudioLibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace AudioLibraryManager.View
{
    public partial class CreateTrackView : Window
    {
        public Track NewTrack { get; set; }

        public List<Genre> Genres { get; set; } = GenreRepository.Instance.GetAll();
        public List<Author> Authors { get; set; } = AuthorRepository.Instance.GetAll();

        private static TimeOnly MINIMAL_TRACK_DURATION = new TimeOnly(0, 0, 10);
        private static TimeOnly MAXIMAL_TRACK_DURATION = new TimeOnly(0, 1, 0);

        public CreateTrackView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeOnly duration = new TimeOnly();

            try
            {
                if(string.IsNullOrEmpty(NameField.Text))
                {
                    throw new Exception("Track name must be given!");
                }
                var formattedInput = $"00:{DurationField.Text}"; 
                if (!TimeOnly.TryParse(formattedInput, out duration))
                {
                    throw new Exception("Time must be given and in correct format (mm:ss)");
                }

                if (!duration.IsBetween(MAXIMAL_TRACK_DURATION, MINIMAL_TRACK_DURATION))
                {
                    throw new Exception($"Track duration must be between {MINIMAL_TRACK_DURATION.ToString("mm:ss")} and " +
                        $"{MAXIMAL_TRACK_DURATION.ToString("mm:ss")}");
                }

                if (ReleaseDateField.SelectedDate == null)
                {
                    throw new Exception("Release date must be selected");
                }

                if (AuthorField.SelectedItem == null)
                {
                    throw new Exception("Author must be selected");
                }

                if (GenreField.SelectedItem == null)
                {
                    throw new Exception("Genre must be selected");
                }

                NewTrack = new Track
                {
                    Name = NameField.Text,
                    Duration = duration,
                    ReleaseDate = ReleaseDateField.SelectedDate.Value,
                    Author = (Author)AuthorField.SelectedItem,
                    Genre = (Genre)GenreField.SelectedItem
                };

                Close();

            } catch (Exception ex)
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
