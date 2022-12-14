using BehKhaan.Infrastructure;
using BehKhaan.Infrastructure.Interfaces;
using BehKhaan.Infrastructure.Repositories;
using BehKhaan.Infrastructure.Services;
using BehKhaan.Infrastructure.Utils;
using BehKhaanAdo.Domain.Entities;
using BehKhaanAdo.Domain.IRepositories;
using BehKhaanAdo.Domain.Utils;
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
            IBookProcedure bookProcedure = new BookProcedure();

            // Initialize database 
            DbInitializer dbInitializer = new DbInitializer(bookProcedure);
            dbInitializer.Seed();

            string? mainMenuItem;
            string? entityMenuItem;

            while (true)
            {
                Console.Write(ShowMainMenu());
                mainMenuItem = Console.ReadLine();
                if (mainMenuItem == "1") // User
                {
                    Console.Write(ShowEntityMenu());
                    entityMenuItem = Console.ReadLine();
                    if (entityMenuItem == "1")
                    {

                    }
                }
                else if (mainMenuItem == "2") // Book
                {
                    Console.Write(ShowEntityMenu());
                    entityMenuItem = Console.ReadLine();
                    if (entityMenuItem == "1")
                    {
                        Console.Write(ShowBookInsertMenu());
                        string[] bookInsertInputs = Console.ReadLine().Split(" ");
                        Book newBook = new Book
                        {
                            ISBN = bookInsertInputs[0],
                            Name = bookInsertInputs[1],
                            Rate = Int32.Parse(bookInsertInputs[2]),
                            Price = Int32.Parse(bookInsertInputs[3])
                        };
                        bookRepo.Insert(newBook);
                        Console.WriteLine("The book was successfully inserted\n");
                    }
                    else if (entityMenuItem == "2")
                    {
                        string bookTable = DataUtils.DataTableToString(bookRepo.GetAll());
                        Console.Write(bookTable);
                    }
                    else if (entityMenuItem == "3")
                    {
                        Console.Write(ShowBookEditMenu());
                        string[] bookEditInputs = Console.ReadLine().Split(" ");
                        Book newBook = new Book
                        {
                            Id = bookEditInputs[0],
                            ISBN = bookEditInputs[1],
                            Name = bookEditInputs[2],
                            Rate = Int32.Parse(bookEditInputs[3]),
                            Price = Int32.Parse(bookEditInputs[4])
                        };
                        bookRepo.Edit(newBook);
                        Console.WriteLine("The book was successfully edited\n");
                    }
                    else if (entityMenuItem == "4")
                    {
                        Console.Write(ShowBookRemoveMenu());
                        string bookRemoveInput = Console.ReadLine();
                        bookRepo.Remove(bookRemoveInput);
                        Console.WriteLine("The book was successfully removed\n");
                    }
                    else if (entityMenuItem == "5")
                    {
                        Console.Write(ShowBookGetByIdMenu());
                        string bookGetByIdInput = Console.ReadLine();

                        string book = DataUtils.DataTableToString(bookRepo.GetById(bookGetByIdInput));
                        Console.Write(book);
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

        public static string ShowBookInsertMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ISBN, Name, Rate, and Price in order and with a space \n");

            return sbuf.ToString();
        }

        public static string ShowBookEditMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId, new ISBN, new Name, new Rate, and new Price in order and with a space \n");

            return sbuf.ToString();
        }

        public static string ShowBookRemoveMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId\n");

            return sbuf.ToString();
        }

        public static string ShowBookGetByIdMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId\n");

            return sbuf.ToString();
        }

    }
}
