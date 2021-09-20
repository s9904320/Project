using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.DB_Context
{
    public class DB_Student : DbContext
    {
        public DB_Student(DbContextOptions<DB_Student> options) : base(options) { }
        public DbSet<StudentInfoT> StudentInfo { get; set; }
    }
}
