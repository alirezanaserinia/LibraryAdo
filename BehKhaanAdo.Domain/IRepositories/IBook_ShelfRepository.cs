using BehKhaanAdo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Domain.IRepositories
{
    public  interface IBook_ShelfRepository
    {
        public DataTable GetAll();
        public DataTable GetById(string bookId, string shelfId);
        public void Insert(Book_Shelf entity);
        public void Edit(Book_Shelf entity);
        public void Remove(string bookId, string shelfId);
    }
}
