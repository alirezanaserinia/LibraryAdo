using BehKhaan.Infrastructure.Utils;
using BehKhaanAdo.Domain.Entities;
using BehKhaanAdo.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo.Menu.Entities
{
    public class BookMenu
    {
        IBookRepository _bookRepo;
        public BookMenu(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public void Handle()
        {
            Console.Write(ShowMenu());
            string item = Console.ReadLine();

            if (item == "1")
            {
                InsertHandler();
            }
            else if (item == "2")
            {
                GetAllHandler();
            }
            else if (item == "3")
            {
                EditHandler();
            }
            else if (item == "4")
            {
                RemoveHandler();
            }
            else if (item == "5")
            {
                GetByIdHandler();
            }
            else if (item == "6")
            {
                // continue meaning back option
            }
            else
            {
                Console.WriteLine("There is no such option!\n");
            }
        }

        private string ShowMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("What do you want to do?\n\t" +
                            "1. Insert \n\t" +
                            "2. Read all \n\t" +
                            "3. Edit \n\t" +
                            "4. Remove \n\t" +
                            "5. Read by id\n\t" +
                            "6. Back \n");

            return sbuf.ToString();
        }

        private void InsertHandler()
        {
            Console.Write(ShowInsertMenu());
            string[] insertInputs = Console.ReadLine().Split(" ");
            Book newBook = new Book
            {
                ISBN = insertInputs[0],
                Name = insertInputs[1],
                Rate = Int32.Parse(insertInputs[2]),
                Price = Int32.Parse(insertInputs[3])
            };
            _bookRepo.Insert(newBook);
            Console.WriteLine("The book was successfully inserted\n");
        }

        private void GetAllHandler()
        {
            string bookTable = DataUtils.DataTableToString(_bookRepo.GetAll());
            Console.Write(bookTable);
        }

        private void EditHandler()
        {
            Console.Write(ShowEditMenu());
            string[] editInputs = Console.ReadLine().Split(" ");
            Book newBook = new Book
            {
                Id = editInputs[0],
                ISBN = editInputs[1],
                Name = editInputs[2],
                Rate = Int32.Parse(editInputs[3]),
                Price = Int32.Parse(editInputs[4])
            };
            _bookRepo.Edit(newBook);
            Console.WriteLine("The book was successfully edited\n");
        }

        private void RemoveHandler()
        {
            Console.Write(ShowRemoveMenu());
            string removeInput = Console.ReadLine();
            _bookRepo.Remove(removeInput);
            Console.WriteLine("The book was successfully removed\n");
        }

        private void GetByIdHandler()
        {
            Console.Write(ShowGetByIdMenu());
            string getByIdInput = Console.ReadLine();

            string book = DataUtils.DataTableToString(_bookRepo.GetById(getByIdInput));
            Console.Write(book);
            Console.WriteLine();
        }

        private string ShowInsertMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ISBN, Name, Rate, and Price in order and with a space \n");

            return sbuf.ToString();
        }

        private string ShowEditMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId, new ISBN, new Name, new Rate, and new Price in order and with a space \n");

            return sbuf.ToString();
        }

        private string ShowRemoveMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId\n");

            return sbuf.ToString();
        }

        private string ShowGetByIdMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId\n");

            return sbuf.ToString();
        }

    }
}
