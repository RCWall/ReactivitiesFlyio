
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // Attribute indicating that this method responds to HTTP GET requests.
        [HttpGet] //api/activities

        // Asynchronous method 'GetActivities' to handle GET requests and return a list of 'Activity' objects.
        public async Task<IActionResult> GetActivities()
        {
            // 'Mediator.Send' sends a new 'List.Query()' request to the MediatR mediator.
            // MediatR then finds the appropriate handler for this request type and executes it.
            // The 'List.Query()' is a request to get a list of activities, which MediatR routes to its corresponding handler.
            // The method awaits the response from the handler, which is a list of 'Activity' objects, and returns this list.
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        
        [HttpGet("{id}")] //api/activities/fdfd
        public async Task<IActionResult> GetActivity(Guid id)
        {
        
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult( await Mediator.Send(new Create.Command { Activity = activity }));
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
            
        }
    }
}