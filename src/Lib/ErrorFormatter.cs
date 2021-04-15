using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
  public class ErrorFormatter {
    
    public static ObjectResult FormatResult(ObjectResult result, string message) {
      var error = new {
        message = "message"
      };

      result.ContentTypes.Add("application/json");
      result.Value = JsonSerializer.Serialize(error);
      return result;
    }

    public static BadRequestObjectResult BadRequest(string message) {
      return (BadRequestObjectResult) FormatResult(new BadRequestObjectResult(""), message);
    }

    public static UnauthorizedObjectResult Unauthorized(string message) {
      return (UnauthorizedObjectResult) FormatResult(new UnauthorizedObjectResult(""), message);
    }

    public static UnauthorizedObjectResult Forbidden(string message) {
      var error = (UnauthorizedObjectResult) FormatResult(new UnauthorizedObjectResult(""), message);
      error.StatusCode = 403;
      return error;
    }

    public static NotFoundObjectResult NotFound(string message) {
      return (NotFoundObjectResult)FormatResult(new NotFoundObjectResult(""), message);
    }

    public static ConflictObjectResult Conflict(string message) {
      return (ConflictObjectResult)FormatResult(new ConflictObjectResult(""), message);
    }
  }
}