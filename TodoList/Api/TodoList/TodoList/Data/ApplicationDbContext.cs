using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data;

public partial class ApplicationDbContext : DbContext
{
  

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDo> ToDos { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ToDos__3214EC07186BF234");

            entity.Property(e => e.Done).HasDefaultValue(false);
            entity.Property(e => e.IsEditing).HasDefaultValue(false);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
