using Microsoft.AspNetCore.Identity;
using NotesProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public List<Category> Categories { get; set; }
}

