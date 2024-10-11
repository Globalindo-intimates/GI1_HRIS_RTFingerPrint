using Microsoft.EntityFrameworkCore;
using RTFFingerPrint_WebAPI.Models;

namespace RTFFingerPrint_WebAPI.Data {
   public class DbContextClass: DbContext {
      public DbContextClass(DbContextOptions<DbContextClass> options): base(options) { }

      public DbSet<AttandenceLog> attandenceLog { get; set;}
      public DbSet<MesinAbsen> mesinabsen { get; set; }
   }
}
