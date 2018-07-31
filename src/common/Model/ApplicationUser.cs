using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }
    }
}
