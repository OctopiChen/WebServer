﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebServer.Models.WebServerDB
{
    public partial class WebServerDBContext : DbContext
    {
        public WebServerDBContext()
        {
        }

        public WebServerDBContext(DbContextOptions<WebServerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<CardHistory> CardHistory { get; set; }
        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<ForgotPassword> ForgotPassword { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuTranslation> MenuTranslation { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<vwMenu> vwMenu { get; set; }
        public virtual DbSet<vwMenuStructure> vwMenuStructure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasIndex(e => e.CardNo, "IX_Card_CardNo")
                    .IsUnique();

                entity.Property(e => e.ID).HasColumnType("TEXT (36)");

                entity.Property(e => e.CardNo).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Card)
                    .HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<CardHistory>(entity =>
            {
                entity.Property(e => e.ID).HasColumnType("TEXT (36)");

                entity.Property(e => e.PunchInDateTime).IsRequired();

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardHistory)
                    .HasForeignKey(d => d.CardID);
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.Property(e => e.ConnectDT).HasColumnType("Text");

                entity.Property(e => e.IP).HasColumnType("Text");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Connection)
                    .HasForeignKey(d => d.UserID);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Path).IsRequired();
            });

            modelBuilder.Entity<ForgotPassword>(entity =>
            {
                entity.Property(e => e.ExpiryDateTime).IsRequired();

                entity.Property(e => e.UserID).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ForgotPassword)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasIndex(e => e.Code, "IX_Menu_Code")
                    .IsUnique();

                entity.Property(e => e.Code).IsRequired();

                entity.HasOne(d => d.PIDNavigation)
                    .WithMany(p => p.InversePIDNavigation)
                    .HasForeignKey(d => d.PID);
            });

            modelBuilder.Entity<MenuTranslation>(entity =>
            {
                entity.Property(e => e.LanguageID).IsRequired();

                entity.Property(e => e.MenuID).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.MenuTranslation)
                    .HasForeignKey(d => d.LanguageID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuTranslation)
                    .HasForeignKey(d => d.MenuID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Account).IsRequired();

                entity.Property(e => e.Birthday).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<vwMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMenu");
            });

            modelBuilder.Entity<vwMenuStructure>(entity =>
            {
                entity.Property(e => e.IDs).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}