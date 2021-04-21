using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.Web.Models
{
    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}