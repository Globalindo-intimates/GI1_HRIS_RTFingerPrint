using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Services {
   public interface IMesinAbsenService {
      Task<List<MesinAbsenDTO>> GetAllMesinAbsen();
   }
}
