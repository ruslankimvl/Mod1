using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.Model
{
    public class UserMenu
    {
        public bool Registration(User user, out string message)
        {
            try
            {
                using (var db = new LiteDatabase("Book.db"))
                {
                    var users = db.GetCollection<User>("Users");
                    users.Insert(user);

                    message = "Registered";
                    return true;
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }
        public User LogOn(string login, string password, out string message)
        {
            User user = null;

            try
            {
                using (var db = new LiteDatabase(@"kkb.db"))
                {

                    var users = db.GetCollection<User>("Users");

                    IEnumerable<User> results =
                    users.Find(x => x.name.Equals(login) &&
                    x.password.Equals(password));

                    if (results.Any())
                    {
                        message = "";
                        return results.FirstOrDefault();
                    }
                    else
                    {
                        message = "Неправильно ввели логин или пароль";
                        return user;
                    }

                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return user;
            }

        }
    }
}