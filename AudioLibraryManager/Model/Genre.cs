using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibraryManager.Model
{
    public class Genre
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

    }
}
