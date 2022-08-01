using BehKhaanAdo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Domain.IRepositories
{
    public interface IBookRepository
    {
        public DataTable GetAll();
        public DataTable GetById(string id);
        public void Insert(Book entity);
        public void Edit(Book entity);
        public void Remove(string id);
    }
}
