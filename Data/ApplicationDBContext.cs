
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_management_system.Models;

namespace task_management_system.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
    }
}