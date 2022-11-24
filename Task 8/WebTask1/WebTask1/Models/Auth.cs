using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTask1.Models
{
    public static class Auth
    {
        public static bool CanLogin(string Login, string Password)
        {
            JsonConverter jsonConverter = new JsonConverter();
            foreach (var user in jsonConverter.DictOfUsers)
            {
                if (user.Key == Login && user.Value.pass == Password)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanRegister(string Login)
        {
            JsonConverter jsonConverter = new JsonConverter();
            foreach(var user in jsonConverter.DictOfUsers)
            {
                if (user.Key == Login)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<User> usersTest()
        {
            return new List<User>();
        }
    }
}