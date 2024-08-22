using Newtonsoft.Json;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace UI.Console2 {
   public class Helpers {
      public async Task<List<MesinAbsenDTO>> GetMesinAbsenAsync() {
         using HttpClient client = new HttpClient();
         //var response = await client.GetAsync("https://localhost:7020/api/MesinAbsens");
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         var response = await client.GetAsync("http://192.168.10.3/api/MesinAbsens");
         var result = await response.Content.ReadFromJsonAsync<List<MesinAbsenDTO>>();
         //List<MesinAbsenDTO>? mesinAbsenDTOs = JsonConvert.DeserializeObject<List<MesinAbsenDTO>>(result);
         return result!;
      }
   }
}
