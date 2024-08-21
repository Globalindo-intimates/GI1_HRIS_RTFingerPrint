using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs {
   public class AttandenceLogDTO {
      public int idx { get; set; }
      public string? NIK { get; set; }
      public DateTime? enroll { get; set; }
      public string? deviceID { get; set; }
      public string? deviceIP { get; set; }
   }
}
