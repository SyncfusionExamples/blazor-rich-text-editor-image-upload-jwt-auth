
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1
{
    [Route("api/[controller]")]
    public class ImageUploadController : Controller
    {
       
        private readonly IWebHostEnvironment hostingEnv;

        public ImageUploadController(IWebHostEnvironment env)
        {
            this.hostingEnv = env;
        }

        
        [HttpPost("[action]")]
        [Route("api/Home/SaveRte")]
        [HttpPost]
        public async Task<IActionResult> Save(IList<IFormFile> UploadFiles)
        {

            string targetPath = hostingEnv.ContentRootPath + "\\wwwroot\\Images";
            // Step 1: Retrieve custom form data from the request
            if (!Request.Headers.TryGetValue("authToken", out var tokenString) || string.IsNullOrEmpty(tokenString))
            {
                return BadRequest("Authentication token is required.");
            }

            string authToken = tokenString.ToString();

            // Step 2: Validate the token (example: Simple check; use JWT handler in production)
            if (!ValidateToken(authToken))
            {
                return Unauthorized("Invalid or expired authentication token.");
            }

            // Optional: Retrieve other custom data
            if (Request.Headers.TryGetValue("userId", out var userIdString))
            {
                string userId = userIdString.ToString();
                // Log or use userId for access control, e.g., check permissions
                Console.WriteLine($"Upload from user: {userId}");
            }

            // Step 3: Process uploaded files
            if (UploadFiles == null || UploadFiles.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            foreach (var file in UploadFiles)
            {
                if (file.Length > 0)
                {
                    // Validate file type/size (e.g., images only, < 5MB)
                    if (!IsValidImageFile(file))
                    {
                        return BadRequest("Invalid file type.");
                    }

                    // Save the file
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(targetPath, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));  // Ensure folder exists

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            // Step 4: Return success response (Rich Text Editor expects JSON with file URL)
            return Ok(new { success = true, message = "Files uploaded successfully." });
        }

        // Helper: Basic token validation (replace with real JWT validation)
        private bool ValidateToken(string token)
        {
            // In production: Use Microsoft.AspNetCore.Authentication.JwtBearer
            // e.g., var handler = new JwtSecurityTokenHandler();
            // Validate against your secret key and claims.
            return token.StartsWith("testAdmin") && token.Length > 5;  // Dummy check
        }

        // Helper: Validate image files
        private bool IsValidImageFile(IFormFile file)
        {
            var allowedTypes = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return allowedTypes.Contains(extension) && file.Length < 5 * 1024 * 1024;  // <5MB
        }



    }
}
