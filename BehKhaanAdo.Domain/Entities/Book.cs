using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Domain.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public int Price { get; set; }
    }
}
