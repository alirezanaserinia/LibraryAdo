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
                    Console.Write(ShowEntityMenu());
                    entityMenuItem = Console.ReadLine();
                    if (entityMenuItem == "1")
                    {
                        Console.Write(ShowShelfInsertMenu());
                        string[] shelfInsertInputs = Console.ReadLine().Split(" ");
                        Shelf newShelf = new Shelf
                        {
                            Name = shelfInsertInputs[0],
                            UserId = shelfInsertInputs[1]
                        };
                        shelfRepo.Insert(newShelf);
                        Console.WriteLine("The shelf was successfully inserted\n");
                    }
                    else if (entityMenuItem == "2")
                    {
                        string shelfTable = DataUtils.DataTableToString(shelfRepo.GetAll());
                        Console.Write(shelfTable);
                    }
                    else if (entityMenuItem == "3")
                    {
                        Console.Write(ShowShelfEditMenu());
                        string[] shelfEditInputs = Console.ReadLine().Split(" ");
                        Shelf newShelf = new Shelf
                        {
                            Id = shelfEditInputs[0],
                            Name = shelfEditInputs[1],
                            UserId = shelfEditInputs[2]
                        };
                        shelfRepo.Edit(newShelf);
                        Console.WriteLine("The shelf was successfully edited\n");
                    }
                    else if (entityMenuItem == "4")
                    {
                        Console.Write(ShowShelfRemoveMenu());
                        string shelfRemoveInput = Console.ReadLine();
                        shelfRepo.Remove(shelfRemoveInput);
                        Console.WriteLine("The shelf was successfully removed\n");
                    }
                    else if (entityMenuItem == "5")
                    {
                        Console.Write(ShowShelfGetByIdMenu());
                        string shelfGetByIdInput = Console.ReadLine();

                        string shelf = DataUtils.DataTableToString(shelfRepo.GetById(shelfGetByIdInput));
                        Console.Write(shelf);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("There is no such option!\n");
                    }
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

        public static string ShowEntityMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("What do you want to do?\n\t" +
                            "1. Insert \n\t" +
                            "2. Read all \n\t" +
                            "3. Edit \n\t" +
                            "4. Remove \n\t" +
                            "5. Read by id\n");

            return sbuf.ToString();
        }

        public static string ShowShelfInsertMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter Name and UserId in order and with a space \n");

            return sbuf.ToString();
        }

        public static string ShowShelfGetByIdMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ShelfId\n");

            return sbuf.ToString();
        }

        public static string ShowShelfEditMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ShelfId, new Name, and new UserId in order and with a space \n");

            return sbuf.ToString();
        }

        public static string ShowShelfRemoveMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ShelfId\n");

            return sbuf.ToString();
        }

    }
}
