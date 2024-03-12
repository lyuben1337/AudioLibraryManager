using System;

namespace AudioLibraryManager.Model
{
    public class Genre
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

    }
}
