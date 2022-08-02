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

        private void InsertHandler()
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

        private void GetAllHandler()
        {
            string userTable = DataUtils.DataTableToString(_userRepo.GetAll());
            Console.Write(userTable);
        }

        private void EditHandler()
        {
            Console.Write(ShowEditMenu());
            string[] editInputs = Console.ReadLine().Split(" ");
            User newUser = new User
            {
                Id = editInputs[0],
                UserName = editInputs[1],
                FullName = editInputs[2]
            };
            _userRepo.Edit(newUser);
            Console.WriteLine("The user was successfully edited\n");
        }

        private void RemoveHandler()
        {
            Console.Write(ShowRemoveMenu());
            string removeInput = Console.ReadLine();
            _userRepo.Remove(removeInput);
            Console.WriteLine("The user was successfully removed\n");
        }

        private void GetByIdHandler()
        {
            Console.Write(ShowGetByIdMenu());
            string getByIdInput = Console.ReadLine();

            string user = DataUtils.DataTableToString(_userRepo.GetById(getByIdInput));
            Console.Write(user);
            Console.WriteLine();
        }
    }
}
