using Newtonsoft.Json;
using Shared;
using Shared.DTOs;
using static System.Net.Http.HttpClient;

namespace UI.Console {
   public class Program {
      public static List<MesinAbsenDTO>? mesinAbsenDTOs = new List<MesinAbsenDTO>();
      static async Task Main(string[] args) {
         var result = await GetMesinAbsenAsync();
         mesinAbsenDTOs = JsonConvert.DeserializeObject<List<MesinAbsenDTO>>(result);
         foreach(MesinAbsenDTO mesin in mesinAbsenDTOs) {
            FingerPrintDevice fD = new FingerPrintDevice(mesin.IpMesin, mesin.Port, mesin.NoMesin);
            fD.Connect();
         }

         
      }
      

      public static async Task<string> GetMesinAbsenAsync() {
         using HttpClient client = new HttpClient();
         var response = await client.GetAsync("https://localhost:7020/api/MesinAbsens");
         var result = await response.Content.ReadAsStringAsync();

         return result;
      }
   }
}