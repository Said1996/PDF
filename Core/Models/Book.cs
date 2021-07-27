using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FilePath { get; set; }

        public int LastPage { get; set; }

        public bool LastlyOpened { get; set; }

        public Library ParentLibrary { get; set; }
    }
}
