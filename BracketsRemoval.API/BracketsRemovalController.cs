using BracketsRemoval.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BracketsRemoval.API
{
    [ApiController]
    [Route("brackets")]
    public class BracketsRemovalController : ControllerBase
    {
        [HttpPost("fixString")]
        public async Task<Response> GetFixedString([FromBody] Request request)
        {
            try
            {
                string result = BracketsService.RemoveExtraBrackets(request.OriginalText);
                var response = new Response
                {
                    FixedText = result,
                    Request = request,
                    ErrorMessage = string.Empty,
                    Status = 200
                };
                return response;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    FixedText = string.Empty,
                    Request = request,
                    ErrorMessage = ex.Message,
                    Status = 500
                };
            }
        }
    }
}