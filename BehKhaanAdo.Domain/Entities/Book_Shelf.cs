using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Domain.Entities
{
    public class Book_Shelf
    {
        public string ISBN { get; set; }
        public int ShelfId { get; set; }
        public int StudyState { get; set; }
    }
}
