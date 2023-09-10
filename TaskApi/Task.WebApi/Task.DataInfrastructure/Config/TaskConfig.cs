using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.DataInfrastructure.Config
{
    public class TaskConfig : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("tbl_task");
            builder.HasKey(k => k.Id);
        }
    }
}
