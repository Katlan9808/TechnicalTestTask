using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task.Domain.Entities;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=taskproject;Password=juliangc;Data Source=localhost:1521/XEPDB1;");

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
