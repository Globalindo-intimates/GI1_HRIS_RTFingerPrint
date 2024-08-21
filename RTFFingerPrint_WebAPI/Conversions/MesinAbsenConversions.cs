using RTFFingerPrint_WebAPI.Models;
using RTFFingerPrint_WebAPI.Services;
using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Conversions {
   public static class MesinAbsenConversions {
      public static List<MesinAbsenDTO> ConvertToDTO(this List<MesinAbsen> mesinAbsens) {
         return(
            from m in mesinAbsens select new MesinAbsenDTO {
               Id = m.Id,
               IpMesin = m.IpMesin,
               NoMesin = m.NoMesin,
               Port = m.Port
            }
        ).ToList();
      }

      public static MesinAbsenDTO ConvertToDTO(this MesinAbsen m) {
         return new MesinAbsenDTO {
            Id = m.Id,
            IpMesin = m.IpMesin,
            NoMesin = m.NoMesin,
            Port = m.Port
         };
      }

      public static List<MesinAbsen> ConvertToModel(this List<MesinAbsenDTO> mesinAbsenDTOs) {
         return (
            from m in mesinAbsenDTOs
            select new MesinAbsen {
               Id = m.Id,
               IpMesin = m.IpMesin,
               NoMesin = m.NoMesin,
               Port = m.Port
            }
         ).ToList();
      }

      public static MesinAbsen ConvertToModel(this MesinAbsen m) {
         return new MesinAbsen {
            Id = m.Id,
            IpMesin = m.IpMesin,
            NoMesin = m.NoMesin,
            Port = m.Port
         };
      }
   }
}
