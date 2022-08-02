using BehKhaanAdo.Domain.IRepositories;
using BehKhaanAdo.Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaanAdo
{
    public class LibraryController
    {
        IBookRepository _bookRepo;
        IUserRepository _userRepo;
        IShelfRepository _shelfRepo;

        public LibraryController(IBookRepository bookRepo, IUserRepository userRepo, IShelfRepository shelfRepo)
        {
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _shelfRepo = shelfRepo;
        }

        public void Run()
        {
            string mainMenuItem;

            UserMenu userMenu = new UserMenu(_userRepo);
            BookMenu bookMenu = new BookMenu(_bookRepo);
            ShelfMenu shelfMenu = new ShelfMenu(_shelfRepo);

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

        private string ShowMainMenu()
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
