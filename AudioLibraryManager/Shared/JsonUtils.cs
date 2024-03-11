using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibraryManager.Shared
{
    public static class JsonUtils
    {
        public static string GetTracks()
        {
            return
                """
                [
                  {
                    "Id": "71c3f5a0-6da1-4b80-b7a8-4e1a9746f4c5",
                    "Name": "Track 1",
                    "Duration": "00:04:30",
                    "Author": {
                      "Id": "10e0f320-4bb5-4bf8-95ea-660899dfb8c6",
                      "Name": "Author 1",
                      "Country": "Country 1"
                    },
                    "Genre": {
                      "Id": "2dfe541f-334a-4a09-a7c1-8eac60a4164b",
                      "Name": "Genre 1"
                    },
                    "ReleaseDate": "2023-01-15T00:00:00",
                    "FormattedReleaseDate": "15 Jan. 2023",
                    "FormattedDuration": "04:30"
                  },
                  {
                    "Id": "eb45a6e9-5e1b-448d-ae90-17a2b5a39a42",
                    "Name": "Track 2",
                    "Duration": "00:03:20",
                    "Author": {
                      "Id": "45a15f48-8b79-4ea8-95cc-567c5b2a428e",
                      "Name": "Author 2",
                      "Country": "Country 2"
                    },
                    "Genre": {
                      "Id": "dcb5ed50-6e39-4a82-862a-88762c3f9e5c",
                      "Name": "Genre 2"
                    },
                    "ReleaseDate": "2022-08-25T00:00:00",
                    "FormattedReleaseDate": "25 Aug. 2022",
                    "FormattedDuration": "03:20"
                  },
                  {
                    "Id": "8f6b8f54-d1d8-4da7-a3d5-9d22632c6979",
                    "Name": "Track 3",
                    "Duration": "00:05:15",
                    "Author": {
                      "Id": "f8e3d460-90c1-4b4a-920a-5c5294153da1",
                      "Name": "Author 3",
                      "Country": "Country 3"
                    },
                    "Genre": {
                      "Id": "f56b46f8-c60e-4ad8-8e4e-76460564b90e",
                      "Name": "Genre 3"
                    },
                    "ReleaseDate": "2024-02-10T00:00:00",
                    "FormattedReleaseDate": "10 Feb. 2024",
                    "FormattedDuration": "05:15"
                  }
                ]
                """;
        }
    }
}
