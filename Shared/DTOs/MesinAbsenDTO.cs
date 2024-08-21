using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs {
   public class MesinAbsenDTO {
      public int Id { get; set; }
      public int NoMesin { get; set; }
      public string? IpMesin { get; set; }
      public int Port { get; set; }
   }
}
