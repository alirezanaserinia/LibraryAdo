using BehKhaan.Infrastructure;
using BehKhaan.Infrastructure.Interfaces;
using BehKhaan.Infrastructure.Repositories;
using BehKhaan.Infrastructure.Services;
using BehKhaanAdo.Domain.IRepositories;
using System;
using System.Data;
using System.Text;

namespace BehKhaanAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository bookRepo = new BookRepository();
            IUserRepository userRepo = new UserRepository();
            IShelfRepository shelfRepo = new ShelfRepository();

            IBookProcedure bookProcedure = new BookProcedure();
            IUserProcedure userProcedure = new UserProcedure();
            IShelfProcedure shelfProcedure = new ShelfProcedure();

            // Initialize database 
            DbInitializer dbInitializer = new DbInitializer(bookProcedure, userProcedure, shelfProcedure);
            dbInitializer.Initialize();

            // Run Application
            LibraryController controller = new LibraryController(bookRepo, userRepo, shelfRepo);
            controller.Run();

        }
    }
}
