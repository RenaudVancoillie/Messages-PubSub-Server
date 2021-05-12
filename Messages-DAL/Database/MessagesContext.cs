using System;
using Messages_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Messages_DAL.Database
{
    public partial class MessagesContext : DbContext
    {
        public MessagesContext()
        {
        }

        public MessagesContext(DbContextOptions<MessagesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Messages;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chats");

                entity.HasIndex(e => e.Guid, "UQ__chats__497F6CB52BDA7CF9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChatId).HasColumnName("chat_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Sender)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("sender");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_messages_chats");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
