
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{   
    // Attribute to specify that this controller responds to web API requests.
    [ApiController]

    // Attribute to define the route for the API, using the controller's name in the URL.
    [Route("api/[controller]")]

    // Declaration of the base controller class, inheriting from ControllerBase for API functionalities.
    public class BaseApiController : ControllerBase
    {

        // Private field for storing a reference to the IMediator instance.
        private IMediator _mediator;
        
        // Property to get the IMediator instance, using lazy initialization from the service container.
        // IMediator is used for handling requests and actions in the application without needing direct interaction between different parts of the code.
        // It works like a middleman, managing and directing requests to the appropriate parts of the application.
        protected IMediator Mediator => _mediator ??= 
            HttpContext.RequestServices.GetService<IMediator>();

    }
}