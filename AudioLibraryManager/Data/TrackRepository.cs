using AudioLibraryManager.Model;
using System.Collections.Generic;
using System.Linq;

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

        public static void DeleteAllByGenre (Genre genre)
        {
            if (genre == null)
            {
                return;
            }

            var updatedList = Instance.GetAll();
            updatedList.RemoveAll(t => t.Genre == genre);

            Instance.UpdateAll(updatedList);
        }
    }
}
