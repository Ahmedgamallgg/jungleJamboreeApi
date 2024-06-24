using Microsoft.AspNetCore.Mvc;
using WebApi.HandelResponses;
using WebApi.Helpers;

namespace WebApi.Controllers
{

    public class FileManagerController : BaseController
    {
        public FileManagerController() { }
        [HttpDelete]
        public IActionResult DeleteFile([FromHeader]string ImageUrl)
        {
            try
            {
               var result = DocumentSettings.DeleteFile(ImageUrl);
                if(result ==0)
                return Ok(new ApiResponse(200, "file Deleted successfuly"));
                if (result == -1)
                    return NotFound(new ApiResponse(404, "file Not Found"));

                return BadRequest(new ApiResponse(500, "Internal Server Error"));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
