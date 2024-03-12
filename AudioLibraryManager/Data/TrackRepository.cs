using AudioLibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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

        public static void DeleteAllByGenre(Genre genre)
        {
            if (genre == null)
            {
                return;
            }

            var updatedList = Instance.GetAll();

            updatedList.RemoveAll(t => t.Genre.Id == genre.Id);

            Instance.UpdateAll(updatedList);
        }

        public static void DeleteAllByAuthor(Author author)
        {
            if(author == null)
            {
                return;
            }

            var updatedList = Instance.GetAll();
            updatedList.RemoveAll(t => t.Author.Id == author.Id);

            Instance.UpdateAll(updatedList);
        }

        public static void UpdateAllByAuthor(Author author)
        {
            if(author == null) 
            {
                return;
            }

            var updatedList = Instance.GetAll();
            updatedList
                .FindAll(t => t.Author.Id == author.Id)
                .ForEach(t => t.Author = author);

            Instance.UpdateAll(updatedList);
        }
    }
}
