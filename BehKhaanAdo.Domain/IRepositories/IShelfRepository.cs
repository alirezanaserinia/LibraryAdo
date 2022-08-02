using BehKhaanAdo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Domain.IRepositories
{
    public interface IShelfRepository
    {
        public DataTable GetAll();
        public DataTable GetById(string id);
        public void Insert(Shelf entity);
        public void Edit(Shelf entity);
        public void Remove(string id);
    }
}
