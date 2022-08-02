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
    public class Book_ShelfMenu
    {
        IBook_ShelfRepository _book_ShelfRepo;
        public Book_ShelfMenu(IBook_ShelfRepository book_ShelfRepo)
        {
            _book_ShelfRepo = book_ShelfRepo;
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
            DateTime dateTime = DateTime.Parse(insertInputs[3] + " " + insertInputs[4]);
            Book_Shelf newBook = new Book_Shelf
            {
                BookId = insertInputs[0],
                ShelfId = insertInputs[1],
                StudyState = Int32.Parse(insertInputs[2]),
                PuttingTime = dateTime
            };
            _book_ShelfRepo.Insert(newBook);
            Console.WriteLine("The book was successfully inserted into the shelf\n");
        }
        
        private void GetAllHandler()
        {
            string book_ShelfTable = DataUtils.DataTableToString(_book_ShelfRepo.GetAll());
            Console.Write(book_ShelfTable);
        }
        
        private void EditHandler()
        {
            Console.Write(ShowEditMenu());
            string[] editInputs = Console.ReadLine().Split(" ");
            DateTime dateTime = DateTime.Parse(editInputs[3] + " " + editInputs[4]);
            Book_Shelf newBook_Shelf = new Book_Shelf
            {
                BookId = editInputs[0],
                ShelfId = editInputs[1],
                StudyState = Int32.Parse(editInputs[2]),
                PuttingTime = dateTime
            };
            _book_ShelfRepo.Edit(newBook_Shelf);
            Console.WriteLine("The book_shelf was successfully edited\n");
        }
        
        private void RemoveHandler()
        {
            Console.Write(ShowRemoveMenu());
            string[] removeInputs = Console.ReadLine().Split(" ");
            _book_ShelfRepo.Remove(removeInputs[0], removeInputs[1]);
            Console.WriteLine("The book was successfully removed\n");
        }
        
        private void GetByIdHandler()
        {
            Console.Write(ShowGetByIdMenu());
            string[] getByIdInputs = Console.ReadLine().Split(" ");

            string book_Shelf = DataUtils.DataTableToString(_book_ShelfRepo.GetById(getByIdInputs[0], getByIdInputs[1]));
            Console.Write(book_Shelf);
            Console.WriteLine();
        }
        
        private string ShowInsertMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId, ShelfId, StudyState, PuttingDate, and PuttingTime in order and with a space \n");

            return sbuf.ToString();
        }
        
        private string ShowEditMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId, ShelfId, new StudyState, new PuttingDate, and new PuttingTime in order and with a space \n");

            return sbuf.ToString();
        }
        
        private string ShowRemoveMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId and ShelfId in order and with a space\n");

            return sbuf.ToString();
        }
        
        private string ShowGetByIdMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter BookId and ShelfId in order and with a space\n");

            return sbuf.ToString();
        }
    }
}
