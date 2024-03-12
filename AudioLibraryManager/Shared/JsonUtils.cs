using System;
using System.IO;
using System.Windows;

namespace AudioLibraryManager.Shared
{
    public static class JsonUtils
    {
        private static string BASE_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;

        private static string AUTHORS_PATH = Path.Combine(BASE_DIRECTORY, "Json\\authors.json");

        private static string GENRES_PATH = Path.Combine(BASE_DIRECTORY, "Json\\genres.json");

        private static string TRACKS_PATH = Path.Combine(BASE_DIRECTORY, "Json\\tracks.json");

        public static string GetAuthorsJson()
        {
            try
            {
                return File.ReadAllText(AUTHORS_PATH);
            }
            catch
            {
                return "";
            }
        }

        public static string GetGenresJson()
        {
            try
            {
                return File.ReadAllText(GENRES_PATH);
            }
            catch
            {
                return "";
            }
        }

        public static string GetTracksJson()
        {
            try
            {
                return File.ReadAllText(TRACKS_PATH);
            }
            catch
            {
                return "";
            }
        }
    }
}
