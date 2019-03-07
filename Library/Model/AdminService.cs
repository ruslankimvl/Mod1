﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AdminService
    {
        public void CreateReader()
        {
            using (var db = new LiteDatabase(@"Readers"))
            {
                var col = db.GetCollection<Reader>("reader");
                Console.WriteLine("Введите логин : ");         
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль : ");
                string password = Console.ReadLine();
                Console.WriteLine("Введите имя : ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите адрес : ");
                string address = Console.ReadLine();
                Console.WriteLine("Введите почту : ");
                string email = Console.ReadLine();
                Console.WriteLine("Введите номер : ");
                string telephoneNumber = Console.ReadLine();
                bool bannedUser = false;

                Reader reader = new Reader(login, password, name, address, email, telephoneNumber, bannedUser);

                col.Insert(reader);
            }
            Libraryy lib = new Libraryy();

        }
        public void ChangePasswordToReader()
        {
            Console.WriteLine("Введите логин пользователя, чтобы поменять пароль: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль пользователя, чтобы поменять пароль");
            string password = Console.ReadLine();
            using (var db = new LiteDatabase(@"Readers"))
            {
                var col = db.GetCollection<Reader>("reader");
                var result = col.FindAll();

                Reader rr = col.FindAll().FirstOrDefault(r => r.password == password && r.login == login);
                if(rr!=null)
                {
                    Console.WriteLine("Введите новый пароль пользователя");
                    string newPassword = Console.ReadLine();
                    rr.password = newPassword;
                    col.Update(rr);
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль");
                }
            }
            Libraryy lib = new Libraryy();

        }
        public void BanReader(Reader reader)
        {
            using (var db = new LiteDatabase(@"Readers"))
            {
                var col = db.GetCollection<Reader>("reader");
                var result = col.FindAll();
                Console.WriteLine("Хотите ли вы заблокировать этого пользователя?(y-да, заблокировать; n- нет, не блокировать): ");
                string chose = Console.ReadLine();
                if (chose == "y")
                {
                    foreach (Reader r in result)
                    {

                        if (r == reader)
                        {
                            r.bannedUser = true;
                        }

                    }
                }
                else if (chose == "n")
                {
                    reader.bannedUser = false;
                }
                col.Update(reader);
            }
            Libraryy lib = new Libraryy();

        }
        public void ChangeAdminPassword()
        {
            Console.WriteLine("Введите логин пользователя, чтобы поменять пароль: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль пользователя, чтобы поменять пароль");
            string password = Console.ReadLine();
            using (var db = new LiteDatabase(@"Admins"))
            {
                var col = db.GetCollection<Admin>("admin");
                var result = col.FindAll();

                Admin a = col.FindAll().FirstOrDefault(aa => aa.password == password && aa.login == login);
                if (a != null)
                {
                    Console.WriteLine("Введите новый пароль пользователя");
                    string newPassword = Console.ReadLine();
                    a.password = newPassword;
                    col.Update(a);
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль");
                }
            }
            Libraryy lib = new Libraryy();

        }
    }
}
