using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    class Library
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
