
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{   
    // Defines a class named 'List' to encapsulate query and handler for activities.
    public class List
    {   
        // 'Query' class, empty in this case, used to represent a request for a list of 'Activity' objects.
        public class Query: IRequest<List<Activity>>{}
        
        // 'Handler' class implements 'IRequestHandler', handling 'Query' requests and returning a list of 'Activity' objects
        public class Handler : IRequestHandler<Query, List<Activity>>
        {  

            // Private field to hold a reference to the database context.
            private readonly DataContext _context;

             // Constructor to initialize the 'Handler' with a 'DataContext' instance.
            public Handler(DataContext context)
            {
            _context = context;
                
            }

            // Asynchronous method 'Handle' to process the 'Query', returning a list of activities.
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {   

                // Asynchronously fetches all 'Activity' entities from the database and converts them into a list.
                // Uses Entity Framework Core's 'ToListAsync()' method for the async operation.     
                return await _context.Activities.ToListAsync();
            }
        }
    }
}