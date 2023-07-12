using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // Trace method
        [Trace]
        [HttpGet]
        public IActionResult TraceMethod()
        {
            return Ok("Trace method called");
        }

        // Connect method
        [Connect]
        [HttpPost]
        public IActionResult ConnectMethod()
        {
            return Ok("Connect method called");
        }

        // Head method
        [Head]
        [HttpHead]
        public IActionResult HeadMethod()
        {
            return Ok("Head method called");
        }

        // File upload using model binding
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok("File uploaded successfully");
            }

            return BadRequest("No file was uploaded");
        }

        // Authentication example
        [Authorize]
        [HttpGet("authenticated")]
        public IActionResult AuthenticatedMethod()
        {
            return Ok("Authenticated method called");
        }

        // HTML response
        [HttpGet("html")]
        public ContentResult HtmlResponse()
        {
            var htmlContent = "<html><body><h1>HTML Response</h1></body></html>";
            return Content(htmlContent, "text/html", Encoding.UTF8);
        }

        // JSON response
        [HttpGet("json")]
        public IActionResult JsonResponse()
        {
            var jsonContent = new { message = "JSON Response" };
            return Ok(jsonContent);
        }

        // XML response
        [HttpGet("xml")]
        public IActionResult XmlResponse()
        {
            var xmlDocument = new XmlDocument();
            var xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(xmlDeclaration);

            var rootElement = xmlDocument.CreateElement("root");
            xmlDocument.AppendChild(rootElement);

            var xmlElement = xmlDocument.CreateElement("message");
            xmlElement.InnerText = "XML Response";
            rootElement.AppendChild(xmlElement);

            return Content(xmlDocument.OuterXml, "application/xml", Encoding.UTF8);
        }
    }
}
