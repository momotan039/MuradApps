
using Microsoft.EntityFrameworkCore;

namespace MuradApps
{
    internal class DbContextHelper: DbContext
    {
        public static DbContextHelper Controller = new DbContextHelper();
        public DbSet<ItemSql> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        //id nums qutur lenM weightK shapeId
       
        //DbSet<Line> Lines { get; set; }
        //DbSet<DoubleLine> DoubleLines { get; set; }
        //DbSet<LightingStrike> LightingStrikes { get; set; }
        //DbSet<Rectangle> Rectangles { get; set; }
        //DbSet<RectangleMissOneWithTails> RectangleMissOneWithTails { get; set; }
        //DbSet<CurvedRectangleMissOneWithTails> CurvedRectangleMissOneWithTails { get; set; }
        //DbSet<CircularDoubleLine> CircularDoubleLines { get; set; }
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydb.db");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}