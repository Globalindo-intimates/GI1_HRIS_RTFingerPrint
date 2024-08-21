using System.ComponentModel.DataAnnotations;

namespace RTFFingerPrint_WebAPI.Models {
   public class AttandenceLog {
      [Key]
      public int idx { get; set; }
      public string? NIK { get; set; }
      public DateTime? enroll { get; set; }
      public string? deviceID { get; set; }
      public string? deviceIP { get; set; }
   }
}
