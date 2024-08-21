using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTFFingerPrint_WebAPI.Services;
using Shared.DTOs;

namespace RTFFingerPrint_WebAPI.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class AttandenceLogController : ControllerBase {
      private readonly IAttandenceLogService attandenceLogService;

      public AttandenceLogController(IAttandenceLogService attandenceLogService) {
         this.attandenceLogService = attandenceLogService;
      }

      [HttpPost]
      public async Task<IActionResult> AddNewlogAsync([FromBody] AttandenceLogDTO attandenceLogDTO) {
         var rst = await this.attandenceLogService.AddNewLog(attandenceLogDTO);
         return Ok(rst);
      }
   }
}
