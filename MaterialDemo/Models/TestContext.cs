using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MaterialDemo.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 获取连接字符串
        string connectionString = App.Configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlite(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("articles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("created_at");
            entity.Property(e => e.Excerpt).HasColumnName("excerpt");
            entity.Property(e => e.Keywords).HasColumnName("keywords");
            entity.Property(e => e.Likes)
                .HasDefaultValue(0)
                .HasColumnName("likes");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("DATETIME")
                .HasColumnName("published_at");
            entity.Property(e => e.Status)
                .HasDefaultValue("draft")
                .HasColumnName("status");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Views)
                .HasDefaultValue(0)
                .HasColumnName("views");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("company");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("CHAR(50)")
                .HasColumnName("address");
            entity.Property(e => e.Age)
                .HasColumnType("INT")
                .HasColumnName("age");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
