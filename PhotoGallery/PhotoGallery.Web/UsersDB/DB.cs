using PhotoGallery.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Web.UsersDB
{
    public class DB
    {
        public static List<User> Users = new List<User>
            {
            new User {Id=1, Email="mail@gmail.com", Password="1234" },
            new User {Id=2, Email="mail2@gmail.com", Password="12345" }
            };
    }
}