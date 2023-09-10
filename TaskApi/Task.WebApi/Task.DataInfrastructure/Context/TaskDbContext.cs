using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task.Domain.Entities;
using Task.Utilities.Encrypt;
using Task.Utilities.Enums;

namespace Task.Domain;

public partial class TaskDbContext : DbContext
{
    public TaskDbContext()
    {
    }

    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TASK> TASK { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string key = Params.KeyEncrypt;
        string connectionString = Encrypt.DecryptString(key, Params.ConecctionString);

        optionsBuilder.UseOracle(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("TASKPROJECT")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TASK>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C008242");

            entity.Property(e => e.ID)
                .HasPrecision(8)
                .HasDefaultValueSql("\"TASKPROJECT\".\"TASK_SEQ\".\"NEXTVAL\"");
            entity.Property(e => e.DATE_CREATED)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE");
            entity.Property(e => e.DATE_UPDATED).HasColumnType("DATE");
            entity.Property(e => e.DESCRIPTION)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DEVELOPER)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.STATUS)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TITLE)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
