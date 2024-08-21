using Microsoft.EntityFrameworkCore;
using RTFFingerPrint_WebAPI.Models;

namespace RTFFingerPrint_WebAPI.Data {
   public class DbContextClass: DbContext {
      public DbContextClass(DbContextOptions<DbContextClass> options): base(options) { }

      public DbSet<AttandenceLog> AttandenceLog { get; set;}
      public DbSet<MesinAbsen> MesinAbsen { get; set; }
   }
}
