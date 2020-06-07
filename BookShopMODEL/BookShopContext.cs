using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookShopMODEL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookShopContext : DbContext
    {
        public BookShopContext() : base("name=BookShopContext")
        {
            Database.SetInitializer<BookShopContext>(new MigrateDatabaseToLatestVersion<BookShopContext,ReportingDbMigrationsConfiguration>());
        }

        public virtual DbSet<BookRatings> BookRatings { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<OrderBook> OrderBook { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<ReaderComments> ReaderComments { get; set; }
        public virtual DbSet<SearchKeywords> SearchKeywords { get; set; }
        public virtual DbSet<TemporaryCart> TemporaryCart { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserStates> UserStates { get; set; }
        public virtual DbSet<RecomBooks> RecomBooks { get; set; }
         internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<BookShopContext>
        {
            public ReportingDbMigrationsConfiguration()
            {
                AutomaticMigrationsEnabled = true;//任何Model Class的修改將會直接更新DB
                AutomaticMigrationDataLossAllowed = true;
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Books>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.OrderBook)
                .WithRequired(e => e.Books)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.ReaderComments)
                .WithRequired(e => e.Books)
                .HasForeignKey(e => e.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderBook>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderBook)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publishers>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publishers)
                .HasForeignKey(e => e.PublisherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReaderComments>()
                .Property(e => e.ReaderName)
                .IsFixedLength();

            modelBuilder.Entity<UserRoles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserRoles)
                .HasForeignKey(e => e.UserRoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserStates>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserStates)
                .HasForeignKey(e => e.UserStateId)
                .WillCascadeOnDelete(false);
        }
    }
}
