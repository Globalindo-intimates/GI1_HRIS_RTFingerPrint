using System.ComponentModel.DataAnnotations;

namespace RTFFingerPrint_WebAPI.Models {
   public class MesinAbsen {
      [Key]
      public int Id { get; set; }
      public int NoMesin { get; set; }
      public string? IpMesin { get; set; }
      public int Port { get; set; }
   }
}
