using RTFFingerPrint_WebAPI.Models;
using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Conversions {
   public static class AttandenceLogConversions {
      public static List<AttandenceLogDTO> ConvertToDTO(this List<AttandenceLog> attandenceLogs) {
         return (
            from m in attandenceLogs select new AttandenceLogDTO {
               idx = m.idx,
               deviceID = m.deviceID,
               deviceIP = m.deviceIP,
               NIK = m.NIK,
               enroll = m.enroll
            }
         ).ToList();
      }

      public static AttandenceLogDTO ConvertToDTO(this AttandenceLog m) {
         return new AttandenceLogDTO {
            idx = m.idx,
            deviceID = m.deviceID,
            deviceIP = m.deviceIP,
            NIK = m.NIK,
            enroll = m.enroll
         };
      }

      public static List<AttandenceLog> ConvertToModel(this List<AttandenceLogDTO> attandenceLogDTOs) {
         return (
            from m in attandenceLogDTOs
            select new AttandenceLog {
               idx = m.idx,
               deviceID = m.deviceID,
               deviceIP = m.deviceIP,
               NIK = m.NIK,
               enroll = m.enroll
            }
         ).ToList();
      }

      public static AttandenceLog ConvertToModel(this AttandenceLogDTO m) {
         return new AttandenceLog {
            idx = m.idx,
            deviceID = m.deviceID,
            deviceIP = m.deviceIP,
            NIK = m.NIK,
            enroll = m.enroll
         };
      }
   }
}
