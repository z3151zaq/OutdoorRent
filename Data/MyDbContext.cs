using Microsoft.EntityFrameworkCore;

namespace WebCoreApi.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData([new Student(){Address = "aaa",Email = "aaa@qq.cpm",Name = "aaa",Id=1},
                new Student(){Address = "bbb",Email = "bbb@qq.cpm",Name = "bbb",Id=2},
                new Student(){Address = "ccc",Email = "ccc@qq.cpm",Name = "ccc",Id=3}
            ]);
        }
    }

}
