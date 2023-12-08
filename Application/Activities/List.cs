
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public class Query: IRequest<Result<List<ActivityDto>>>{}
        
        // 'Handler' class implements 'IRequestHandler', handling 'Query' requests and returning a list of 'Activity' objects
        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {  

            // Private field to hold a reference to the database context.
            private readonly DataContext _context;
            private readonly IMapper _mapper;

             // Constructor to initialize the 'Handler' with a 'DataContext' instance.
            public Handler(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
            _context = context;
                
            }

            // Asynchronous method 'Handle' to process the 'Query', returning a list of activities.
            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {   
                var activities = await _context.Activities
                .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                // Asynchronously fetches all 'Activity' entities from the database and converts them into a list.
                // Uses Entity Framework Core's 'ToListAsync()' method for the async operation.     
                return Result<List<ActivityDto>>.Success(activities);
            }
        }
    }
}