using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OneToOneCrud.EntityFrameworkCore
{
    public static class OneToOneCrudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OneToOneCrudDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OneToOneCrudDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
