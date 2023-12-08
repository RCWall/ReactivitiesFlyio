
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Authorization;
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
            // This method is asynchronous and returns an 'IActionResult', which represents the result of an HTTP request.

            // 'Mediator.Send' sends a new 'Details.Query' with the provided 'id' to be handled by the appropriate handler.
            // 'new Details.Query{Id = id}' creates a new instance of the 'Details.Query' class and sets its 'Id' property.
            // The result of the 'Mediator.Send' operation is a 'Result<T>' object, representing the outcome of the query.
            // 'HandleResult' processes the 'Result<T>' object received from the 'Mediator.Send' operation.
            // The final line returns the HTTP response determined by the 'HandleResult' method.
        
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult( await Mediator.Send(new Create.Command { Activity = activity }));
           
        }
        
        [Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
    
        }
        
        [Authorize(Policy = "IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
            
        }

        [HttpPost("{id}/attend")]

        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command{Id = id}));
        }
    }
}