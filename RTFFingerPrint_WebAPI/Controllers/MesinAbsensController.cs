using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTFFingerPrint_WebAPI.Services;

namespace RTFFingerPrint_WebAPI.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class MesinAbsensController : ControllerBase {
      private readonly IMesinAbsenService mesinAbsenService;

      public MesinAbsensController(IMesinAbsenService mesinAbsenService) {
         this.mesinAbsenService = mesinAbsenService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllMesinAbsenAsync() {
         var result = await mesinAbsenService.GetAllMesinAbsen();
         return Ok(result);
      }
   }
}
