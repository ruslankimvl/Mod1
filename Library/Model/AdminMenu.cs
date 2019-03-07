using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace Library.Model
{
    public class AdminMenu
    {
        Reader Reader;
        public AdminMenu(Admin admin)
        {
            AdminService adminService = new AdminService();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1)Добавить читателя\n2)Изменить пароль админа\n3)Изменить пароль читателя\n4)Добавить в чс \n5)назад");

            int sw = Int32.Parse(Console.ReadLine());
            Console.Clear();

            switch (sw)
            {
                case 1:
                    adminService.CreateReader();
                    break;
                case 2:
                    adminService.ChangeAdminPassword();
                    break;
                case 3:
                    adminService.ChangePasswordToReader();
                    break;
                case 4:
                    adminService.BanReader(Reader);
                    break;
                case 5:
                    Libraryy lib = new Libraryy();
                    break;
            }


        }
    }
}
