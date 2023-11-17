


using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // Attribute indicating that this method responds to HTTP GET requests.
        [HttpGet] //api/activities

        // Asynchronous method 'GetActivities' to handle GET requests and return a list of 'Activity' objects.
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            // 'Mediator.Send' sends a new 'List.Query()' request to the MediatR mediator.
            // MediatR then finds the appropriate handler for this request type and executes it.
            // The 'List.Query()' is a request to get a list of activities, which MediatR routes to its corresponding handler.
            // The method awaits the response from the handler, which is a list of 'Activity' objects, and returns this list.
            return await Mediator.Send(new List.Query());
        }
        
        [HttpGet("{id}")] //api/activities/fdfd
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command { Activity = activity });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new Edit.Command { Activity = activity });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command{Id = id});
            return Ok();
        }
    }
}