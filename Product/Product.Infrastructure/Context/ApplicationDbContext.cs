using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Entities.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Coffee", CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207") },
                    new Category { Id = 2, Name = "Tea", CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207") },
                    new Category { Id = 3, Name = "Banh Mi", CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207") },
                    new Category { Id = 4, Name = "Other", CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207") }
                );

            modelBuilder.Entity<Domain.Entities.Product>()
                .HasData(
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                        Name = "PhinDi Cassia",
                        Description = "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg",
                        CategoryId = 1,
                        Price = 55000,
                        Discount = 0,
                        Stock = 325,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                        Name = "Phindi Hạt Dẻ Cười",
                        Description = "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg",
                        CategoryId = 1,
                        Price = 65000,
                        Discount = 5,
                        Stock = 0,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                        Name = "PhinDi Choco",
                        Description = "Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp cùng Choco ngọt tan mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__PHINDI_CHOCO.jpg",
                        CategoryId = 1,
                        Price = 45000,
                        Discount = 0,
                        Stock = 5,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                        Name = "Golden Lotus Tea (Only Lotus seed)",
                        Description = "Golden Lotus Tea (Only Lotus seed)",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg",
                        CategoryId = 2,
                        Price = 45000,
                        Discount = 0,
                        Stock = 214,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                        Name = "Peach Jelly Tea",
                        Description = "A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TRA_THANH_DAO-09.jpg",
                        CategoryId = 2,
                        Price = 45000,
                        Discount = 10,
                        Stock = 45,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                        Name = "Bánh Mì Que (Gà Phô Mai)",
                        Description = "Bánh mì que gà tại Highlands Coffee mang đến hương vị đậm đà kết hợp với phô mai beo béo, không chỉ ngon miệng mà còn bổ dưỡng, phù hợp cho bữa ăn nhanh gọn.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Ga_Pho_Mai.png",
                        CategoryId = 3,
                        Price = 19000,
                        Discount = 0,
                        Stock = 34,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                        Name = "Bánh Mì Que (Pate)",
                        Description = "Thưởng thức hương vị truyền thống với bánh mì que pate tại Highlands Coffee. Bánh mì giòn tan, kết hợp với pate thơm ngon, tạo nên một món ăn sáng hoàn hảo cho mọi người.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Pate.png",
                        CategoryId = 3,
                        Price = 19000,
                        Discount = 0,
                        Stock = 146,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    },
                    new Domain.Entities.Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                        Name = "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE",
                        Description = "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png",
                        CategoryId =4,
                        Price = 109000,
                        Discount = 3,
                        Stock = 214,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    }
                );
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    (e.Entity is Category || e.Entity is Domain.Entities.Product) &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Category category)
                {
                    if (entry.State == EntityState.Added)
                    {
                        category.CreatedAt = DateUtility.GetCurrentDateTime();
                    }
                    category.LastModifiedAt = DateUtility.GetCurrentDateTime();
                }

                if (entry.Entity is Domain.Entities.Product product)
                {
                    if (entry.State == EntityState.Added)
                    {
                        product.CreatedAt = DateUtility.GetCurrentDateTime();
                    }
                    product.LastModifiedAt = DateUtility.GetCurrentDateTime();
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    (e.Entity is Category || e.Entity is Domain.Entities.Product) &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Category category)
                {
                    if (entry.State == EntityState.Added)
                    {
                        category.CreatedAt = DateUtility.GetCurrentDateTime();
                    }
                    category.LastModifiedAt = DateUtility.GetCurrentDateTime();
                }

                if (entry.Entity is Domain.Entities.Product product)
                {
                    if (entry.State == EntityState.Added)
                    {
                        product.CreatedAt = DateUtility.GetCurrentDateTime();
                    }
                    product.LastModifiedAt = DateUtility.GetCurrentDateTime();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
