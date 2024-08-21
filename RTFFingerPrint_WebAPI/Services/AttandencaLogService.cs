using RTFFingerPrint_WebAPI.Conversions;
using RTFFingerPrint_WebAPI.Data;
using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Services {
   public class AttandencaLogService : IAttandenceLogService {
      private readonly DbContextClass dbContextClass;

      public AttandencaLogService(DbContextClass dbContextClass) {
         this.dbContextClass = dbContextClass;
      }
      public async Task<AttandenceLogDTO> AddNewLog(AttandenceLogDTO attandenceLogDTO) {
         var result = await dbContextClass.AttandenceLog.AddAsync(attandenceLogDTO.ConvertToModel());
         await dbContextClass.SaveChangesAsync();

         return result.Entity.ConvertToDTO();
      }
   }
}
