// Purpose: Fallback controller for routing to the index.html file in the wwwroot folder.
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers

{
   [AllowAnonymous]
    public class FallbackController: Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(
                Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "index.html"
                ), "text/HTML"
            );
        }
        
    }
}