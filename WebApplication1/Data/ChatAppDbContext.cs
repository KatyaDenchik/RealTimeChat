using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.Data
{
    public class ChatAppDbContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>().HasKey(c => c.Id);
            modelBuilder.Entity<ChatMessage>().Property(c => c.UserName).IsRequired();
            modelBuilder.Entity<ChatMessage>().Property(c => c.Message).IsRequired();
            modelBuilder.Entity<ChatMessage>().Property(c => c.Sentiment).IsRequired();
        }
    }
}
