using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class AppUser:IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsStudent { get; set; }
        public bool Gender { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
