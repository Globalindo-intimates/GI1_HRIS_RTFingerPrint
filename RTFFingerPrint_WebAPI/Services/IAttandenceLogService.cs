using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Services {
   public interface IAttandenceLogService {
      Task<AttandenceLogDTO> AddNewLog(AttandenceLogDTO attandenceLogDTO);
   }
}
