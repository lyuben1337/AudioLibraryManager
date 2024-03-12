using AudioLibraryManager.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibraryManager.Model
{
    public class Track
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public TimeOnly Duration { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string FormattedReleaseDate => ReleaseDate.ToString("dd MMM. yyyy");
        public string FormattedDuration => Duration.ToString("mm:ss");
    }
}
