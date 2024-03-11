using AudioLibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibraryManager.Data
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(List<Genre> initialData) : base(initialData)
        {
        }

        public GenreRepository(string json) : base(json)
        {
        }
    }
}
