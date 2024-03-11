using AudioLibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibraryManager.Data
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(List<Author> initialData) : base(initialData)
        {
        }

        public AuthorRepository(string json) : base(json)
        {
        }
    }
}
