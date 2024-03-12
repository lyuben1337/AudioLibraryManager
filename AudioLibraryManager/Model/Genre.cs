using System;

namespace AudioLibraryManager.Model
{
    public class Genre
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

    }
}
