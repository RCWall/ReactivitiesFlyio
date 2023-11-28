

using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{ 
    // 'Details' class contains nested classes related to fetching details of an activity.
    public class Details
    {
        // 'Query' class represents a request for a specific activity, identified by an ID.
        public class Query : IRequest<Result<Activity>>
        {
            // 'Id' property stores the unique identifier of the activity to fetch.
            public Guid Id {get; set; } 
        }
        
        // 'Handler' class processes the 'Query' request and returns a 'Result<Activity>'.
        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
        private readonly DataContext _context;
            // Constructor initializes the 'Handler' with the given database context.
            public Handler(DataContext context)
            {
                _context = context;
                
            }
            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {   
                // Fetch the activity from the database using the ID from the request.
                var activity =  await _context.Activities.FindAsync(request.Id);

                // Return a 'Result' object containing the fetched activity, indicating success.
                return Result<Activity>.Success(activity);
            }
        }
    }
}