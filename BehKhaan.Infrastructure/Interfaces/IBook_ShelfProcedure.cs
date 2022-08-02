using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Interfaces
{
    public interface IBook_ShelfProcedure
    {
        public void CreateInsertBook_ShelfProcedure();
        public void CreateGetBook_ShelfsProcedure();
        public void CreateEditBook_ShelfProcedure();
        public void CreateRemoveBook_ShelfProcedure();
        public void CreateGetBook_ShelfByIdProcedure();
    }
}
