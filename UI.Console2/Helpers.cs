using Newtonsoft.Json;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Console2 {
   public class Helpers {
      public async Task<List<MesinAbsenDTO>> GetMesinAbsenAsync() {
         using HttpClient client = new HttpClient();
         var response = await client.GetAsync("https://localhost:7020/api/MesinAbsens");
         var result = await response.Content.ReadAsStringAsync();
         List<MesinAbsenDTO>? mesinAbsenDTOs = JsonConvert.DeserializeObject<List<MesinAbsenDTO>>(result);
         return mesinAbsenDTOs!;
      }
   }
}
