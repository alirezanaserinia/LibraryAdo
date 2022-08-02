using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Interfaces
{
    public interface IShelfProcedure
    {
        public void CreateInsertShelfProcedure();
        public void CreateGetShelfsProcedure();
        public void CreateEditShelfProcedure();
        public void CreateRemoveShelfProcedure();
        public void CreateGetShelfByIdProcedure();
    }
}
