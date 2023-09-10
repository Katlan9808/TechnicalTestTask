using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataInfrastructure.Config;
using Task.Domain.Entities;

namespace Task.DataInfrastructure.Context
{
    public class ContextTask : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseOracle("");
        }
        

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating (builder);
            builder.ApplyConfiguration(new TaskConfig());
        }
    }
}
