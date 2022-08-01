using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Interfaces
{
    public interface IBookProcedure
    {
        public void CreateInsertBookProcedure();
        public void CreateGetBooksProcedure();
        public void CreateEditBookProcedure();
        public void CreateRemoveBookProcedure();
        public void CreateGetBookByIdProcedure();
    }
}
