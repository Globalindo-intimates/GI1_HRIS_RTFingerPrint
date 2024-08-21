using Microsoft.EntityFrameworkCore;
using RTFFingerPrint_WebAPI.Conversions;
using RTFFingerPrint_WebAPI.Data;
using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Services {
   public class MesinAbsenService : IMesinAbsenService {
      private readonly DbContextClass dbContextClass;

      public MesinAbsenService(DbContextClass dbContextClass) {
         this.dbContextClass = dbContextClass;
      }
      public async Task<List<MesinAbsenDTO>> GetAllMesinAbsen() {
         var mesinAbsens = await this.dbContextClass.MesinAbsen.ToListAsync();

         return mesinAbsens.ConvertToDTO();
      }
   }
}
