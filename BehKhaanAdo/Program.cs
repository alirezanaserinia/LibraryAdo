﻿using BehKhaan.Infrastructure;
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
            IBookProcedure bookProcedure = new BookProcedure();
            IUserProcedure userProcedure = new UserProcedure();
            IShelfProcedure shelfProcedure = new ShelfProcedure();
            IBook_ShelfProcedure book_ShelfProcedure = new Book_ShelfProcedure();
            
            IBookRepository bookRepo = new BookRepository();
            IUserRepository userRepo = new UserRepository();
            IShelfRepository shelfRepo = new ShelfRepository();
            IBook_ShelfRepository book_ShelfRepo = new Book_ShelfRepository();

            // Initialize database 
            DbInitializer dbInitializer = new DbInitializer(bookProcedure, userProcedure, shelfProcedure, book_ShelfProcedure);
            dbInitializer.Initialize();

            // Run Application
            LibraryController controller = new LibraryController(bookRepo, userRepo, shelfRepo, book_ShelfRepo);
            controller.Run();

        }
    }
}
