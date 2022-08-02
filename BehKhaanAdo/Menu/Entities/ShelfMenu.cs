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
    public class ShelfMenu
    {
        private readonly IShelfRepository _shelfRepo;
        public ShelfMenu(IShelfRepository shelfRepo)
        {
            _shelfRepo = shelfRepo;
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
                            "5. Read by id\n");

            return sbuf.ToString();
        }

        private void InsertHandler()
        {
            Console.Write(ShowInsertMenu());
            string[] insertInputs = Console.ReadLine().Split(" ");
            Shelf newShelf = new Shelf
            {
                Name = insertInputs[0],
                UserId = insertInputs[1]
            };
            _shelfRepo.Insert(newShelf);
            Console.WriteLine("The shelf was successfully inserted\n");
        }

        private void GetAllHandler()
        {
            string shelfTable = DataUtils.DataTableToString(_shelfRepo.GetAll());
            Console.Write(shelfTable);
        }

        private void EditHandler()
        {
            Console.Write(ShowEditMenu());
            string[] editInputs = Console.ReadLine().Split(" ");
            Shelf newShelf = new Shelf
            {
                Id = editInputs[0],
                Name = editInputs[1],
                UserId = editInputs[2]
            };
            _shelfRepo.Edit(newShelf);
            Console.WriteLine("The shelf was successfully edited\n");
        }

        private void RemoveHandler()
        {
            Console.Write(ShowRemoveMenu());
            string removeInput = Console.ReadLine();
            _shelfRepo.Remove(removeInput);
            Console.WriteLine("The shelf was successfully removed\n");
        }

        private void GetByIdHandler()
        {
            Console.Write(ShowGetByIdMenu());
            string getByIdInput = Console.ReadLine();

            string shelf = DataUtils.DataTableToString(_shelfRepo.GetById(getByIdInput));
            Console.Write(shelf);
            Console.WriteLine();
        }

        public static string ShowInsertMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter Name and UserId in order and with a space \n");

            return sbuf.ToString();
        }

        public static string ShowGetByIdMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ShelfId\n");

            return sbuf.ToString();
        }

        public static string ShowEditMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ShelfId, new Name, and new UserId in order and with a space \n");

            return sbuf.ToString();
        }

        public static string ShowRemoveMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter ShelfId\n");

            return sbuf.ToString();
        }


    }
}
