using AudioLibraryManager.Model;
using System.Collections.Generic;

namespace AudioLibraryManager.Data
{
    public class TrackRepository : Repository<Track>
    {
        public TrackRepository(List<Track> initialData) : base(initialData)
        {
        }

        public TrackRepository(string json) : base(json)
        {
        }
    }
}
