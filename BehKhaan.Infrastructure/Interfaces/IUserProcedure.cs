using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Interfaces
{
    public interface IUserProcedure
    {
        public void CreateInsertUserProcedure();
        public void CreateGetUsersProcedure();
        public void CreateEditUserProcedure();
        public void CreateRemoveUserProcedure();
        public void CreateGetUserByIdProcedure();
    }
}
