using BaseDB;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DBContext : BaseContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //_ = modelBuilder.ApplyConfiguration(new ExamConfiguration());
        }
    }
}