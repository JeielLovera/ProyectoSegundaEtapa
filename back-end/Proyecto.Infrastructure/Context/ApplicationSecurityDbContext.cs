using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto.Infrastructure.Context.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Context
{
    public class ApplicationSecurityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationSecurityDbContext(DbContextOptions<ApplicationSecurityDbContext> options) : base(options)
        {

        }
    }
}
