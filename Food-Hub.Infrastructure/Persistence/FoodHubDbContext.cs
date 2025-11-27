using Food_Hub.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Food_Hub.Infrastructure.Persistence
{
    public class FoodHubDbContext : DbContext
    {
        public FoodHubDbContext(DbContextOptions<FoodHubDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for all entities
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CategoryOfProduct> CategoryOfProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CategoryOfRestaurant> CategoryOfRestaurants { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<Food_Hub.Core.Entities.Attribute> Attributes { get; set; }
        public DbSet<ProductDetailAttribute> ProductDetailAttributes { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================================
            // User Entity Configuration
            // ============================================
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // Restaurant Entity Configuration
            // ============================================
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.UserId)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                // User (1) -> many Restaurants
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // Customer Entity Configuration
            // ============================================
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired();

                // User (1) -> many Customers
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // Product Entity Configuration
            // ============================================
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500);

                entity.Property(e => e.MerchantId)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                // Restaurant (1) -> many Products
                // Note: FK property is MerchantId but navigation is Restaurant
                entity.HasOne(e => e.Restaurant)
                    .WithMany(r => r.Products)
                    .HasForeignKey(e => e.MerchantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // ProductDetail Entity Configuration
            // ============================================
            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.ProductId)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                // Product (1) -> many ProductDetails
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // ProductOrder Entity Configuration
            // ============================================
            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.OrderId)
                    .IsRequired();

                entity.Property(e => e.ProductDetailId)
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.TotalPrice)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                // Order (1) -> many ProductOrders
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.ProductOrders)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                // ProductDetail (1) -> many ProductOrders
                entity.HasOne(e => e.ProductDetail)
                    .WithMany(pd => pd.ProductOrders)
                    .HasForeignKey(e => e.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // Order Entity Configuration
            // ============================================
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.OrderDate)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Subtotal)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.DeliveryFee)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Tax)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.PaidAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CustomerId)
                    .IsRequired();

                entity.Property(e => e.RestaurantId)
                    .IsRequired();

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(500);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50);

                // Note: Order has CustomerId and RestaurantId but no navigation properties
                // Relationships are configured via ProductOrder and through FKs if needed
            });

            // ============================================
            // CategoryOfProduct Entity Configuration
            // ============================================
            modelBuilder.Entity<CategoryOfProduct>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // ProductCategory Entity Configuration (Composite Key)
            // ============================================
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                // Composite key on (ProductId, CategoryOfProductId)
                entity.HasKey(e => new { e.ProductId, e.CategoryOfProductId });

                entity.Property(e => e.ProductId)
                    .IsRequired();

                entity.Property(e => e.CategoryOfProductId)
                    .IsRequired();

                // Product (1) -> many ProductCategories
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                // CategoryOfProduct (1) -> many ProductCategories
                entity.HasOne(e => e.CategoryOfProduct)
                    .WithMany(cop => cop.ProductCategories)
                    .HasForeignKey(e => e.CategoryOfProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // CategoryOfRestaurant Entity Configuration
            // ============================================
            modelBuilder.Entity<CategoryOfRestaurant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // RestaurantCategory Entity Configuration
            // ============================================
            modelBuilder.Entity<RestaurantCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.RestaurantId)
                    .IsRequired();

                entity.Property(e => e.CategoryOfRestaurantId)
                    .IsRequired();

                // Restaurant (1) -> many RestaurantCategories
                entity.HasOne(e => e.Restaurant)
                    .WithMany(r => r.RestaurantCategories)
                    .HasForeignKey(e => e.RestaurantId)
                    .OnDelete(DeleteBehavior.Restrict);

                // CategoryOfRestaurant (1) -> many RestaurantCategories
                entity.HasOne(e => e.CategoryOfRestaurant)
                    .WithMany(cor => cor.RestaurantCategories)
                    .HasForeignKey(e => e.CategoryOfRestaurantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // Attribute Entity Configuration
            // ============================================
            modelBuilder.Entity<Food_Hub.Core.Entities.Attribute>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Value)
                    .HasMaxLength(500);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // ProductDetailAttribute Entity Configuration
            // ============================================
            modelBuilder.Entity<ProductDetailAttribute>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.ProductDetailId)
                    .IsRequired();

                entity.Property(e => e.AttributeId)
                    .IsRequired();

                entity.Property(e => e.MeasureUnitId)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .HasMaxLength(500);

                // ProductDetail (1) -> many ProductDetailAttributes
                entity.HasOne(e => e.ProductDetail)
                    .WithMany(pd => pd.ProductDetailAttributes)
                    .HasForeignKey(e => e.ProductDetailId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Attribute (1) -> many ProductDetailAttributes
                entity.HasOne(e => e.Attribute)
                    .WithMany(a => a.ProductDetailAttributes)
                    .HasForeignKey(e => e.AttributeId)
                    .OnDelete(DeleteBehavior.Restrict);

                // MeasureUnit (1) -> many ProductDetailAttributes
                entity.HasOne(e => e.MeasureUnit)
                    .WithMany()
                    .HasForeignKey(e => e.MeasureUnitId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // ============================================
            // MeasureUnit Entity Configuration
            // ============================================
            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseMySqlIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                // Note: MeasureUnit has navigation ProductDetails but ProductDetail doesn't have MeasureUnitId
                // The relationship is through ProductDetailAttribute
                // If ProductDetails navigation should be configured, it would be via ProductDetailAttribute
                // For now, we configure the relationship through ProductDetailAttribute (already done above)

                entity.HasQueryFilter(e => !e.IsDeleted);
            });
        }
    }
}

