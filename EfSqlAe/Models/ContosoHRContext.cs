﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EfSqlAe.Models;

public partial class ContosoHRContext : DbContext
{
    public ContosoHRContext()
    {
    }

    public ContosoHRContext(DbContextOptions<ContosoHRContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employees> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string _EnvVar = "DBContosoHRAE";
        var connString = Environment.GetEnvironmentVariable(_EnvVar, EnvironmentVariableTarget.Process);
        optionsBuilder.UseSqlServer(connString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => e.EmployeeID).HasName("PK_dbo.Employees");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SSN)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("Latin1_General_BIN2");
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}