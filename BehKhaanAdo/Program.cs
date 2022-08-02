using BehKhaan.Infrastructure;
using BehKhaan.Infrastructure.Interfaces;
using BehKhaan.Infrastructure.Repositories;
using BehKhaan.Infrastructure.Services;
using BehKhaan.Infrastructure.Utils;
using BehKhaanAdo.Domain.Entities;
using BehKhaanAdo.Domain.IRepositories;
using BehKhaanAdo.Domain.Utils;
using BehKhaanAdo.Menu.Entities;
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

            UserMenu userMenu = new UserMenu(userRepo);
            BookMenu bookMenu = new BookMenu(bookRepo);
            ShelfMenu shelfMenu = new ShelfMenu(shelfRepo);

            // Initialize database 
            DbInitializer dbInitializer = new DbInitializer(bookProcedure, userProcedure, shelfProcedure);
            dbInitializer.Seed();

            string? mainMenuItem;
            string? entityMenuItem;

            while (true)
            {
                Console.Write(ShowMainMenu());
                mainMenuItem = Console.ReadLine();
                if (mainMenuItem == "1") // User
                {
                    userMenu.Handle();
                }
                else if (mainMenuItem == "2") // Book
                {
                    bookMenu.Handle();
                }
                else if (mainMenuItem == "3") // Shelf
                {
                    shelfMenu.Handle();
                }
                else
                {
                    Console.WriteLine("There is no such option!\n");
                }
            }

        }

        public static string ShowMainMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter the number of entity you want:\n\t" +
                            "1. User \n\t" +
                            "2. Book \n\t" +
                            "3. Shelf \n");
            return sbuf.ToString();
        }


    }
}
