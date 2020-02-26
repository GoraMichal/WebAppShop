﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace WebAppShop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
    }

    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}


    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{

    //    public DbSet<Customer> Customers { get; set; }

    //    public ApplicationDbContext() 
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {

    //    }
    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}