using Microsoft.EntityFrameworkCore;

namespace WebCoreApi.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData([new Student(){Address = "aaa",Email = "aaa@qq.cpm",Name = "aaa",Id=1},
                new Student(){Address = "bbb",Email = "bbb@qq.cpm",Name = "bbb",Id=2},
                new Student(){Address = "ccc",Email = "ccc@qq.cpm",Name = "ccc",Id=3}
            ]);
            modelBuilder.Entity<Equipment>()
                .Property(r => r.Condition)
                .HasConversion<string>(); // 存储为字符串
            modelBuilder.Entity<Location>()
                .HasIndex(i=>i.Name)
                .IsUnique(); // unique constraint
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.LocationDetail)
                .WithMany()
                .HasForeignKey(e => e.Location) // Equipment.Location 是 FK
                .HasPrincipalKey(l => l.Name);  // Location.Name 是目标主键（不是 Id）
        }
    }

}
