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
    public class UserMenu
    {
        private readonly IUserRepository _userRepo;
        public UserMenu(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Handle()
        {

            Console.Write(ShowMenu());
            string item = Console.ReadLine();
            if (item == "1")
            {
                Console.Write(ShowInsertMenu());
                string[] insertInputs = Console.ReadLine().Split(" ");
                User newUser = new User
                {
                    UserName = insertInputs[0],
                    FullName = insertInputs[1],
                };
                _userRepo.Insert(newUser);
                Console.WriteLine("The user was successfully inserted\n");
            }
            else if (item == "2")
            {
                string userTable = DataUtils.DataTableToString(_userRepo.GetAll());
                Console.Write(userTable);
            }
            else if (item == "3")
            {
                Console.Write(ShowEditMenu());
                string[] userEditInputs = Console.ReadLine().Split(" ");
                User newUser = new User
                {
                    Id = userEditInputs[0],
                    UserName = userEditInputs[1],
                    FullName = userEditInputs[2]
                };
                _userRepo.Edit(newUser);
                Console.WriteLine("The user was successfully edited\n");
            }
            else if (item == "4")
            {
                Console.Write(ShowRemoveMenu());
                string userRemoveInput = Console.ReadLine();
                _userRepo.Remove(userRemoveInput);
                Console.WriteLine("The user was successfully removed\n");
            }
            else if (item == "5")
            {
                Console.Write(ShowGetByIdMenu());
                string userGetByIdInput = Console.ReadLine();

                string user = DataUtils.DataTableToString(_userRepo.GetById(userGetByIdInput));
                Console.Write(user);
                Console.WriteLine();
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

        private string ShowInsertMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter UserName and FullName in order and with a space \n");

            return sbuf.ToString();
        }

        private string ShowGetByIdMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter UserId\n");

            return sbuf.ToString();
        }

        private string ShowEditMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter UserId, new UserName, and new FullName in order and with a space \n");

            return sbuf.ToString();
        }

        private string ShowRemoveMenu()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append("Enter UserId\n");

            return sbuf.ToString();
        }

    }
}
