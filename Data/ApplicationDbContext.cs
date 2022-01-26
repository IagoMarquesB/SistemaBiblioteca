using Library_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBiblioteca.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Library_System.Models.Author> Author { get; set; }
        public DbSet<Library_System.Models.Book> Book { get; set; }
        public DbSet<Library_System.Models.Publisher> Publisher { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().ToTable("Author")
            .HasMany(b => b.Books);
            modelBuilder.Entity<Book>().ToTable("Book")
            .HasOne(d => d.Author)
            .WithMany(b => b.Books);
            modelBuilder.Entity<Publisher>().ToTable("Publisher")
            .HasMany(b => b.Books);
        }
    }
}
