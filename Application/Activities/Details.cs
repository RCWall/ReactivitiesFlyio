

using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{ 
    // 'Details' class contains nested classes related to fetching details of an activity.
    public class Details
    {
        // 'Query' class represents a request for a specific activity, identified by an ID.
        public class Query : IRequest<Result<ActivityDto>>
        {
            // 'Id' property stores the unique identifier of the activity to fetch.
            public Guid Id {get; set; } 
        }
        
        // 'Handler' class processes the 'Query' request and returns a 'Result<Activity>'.
        public class Handler : IRequestHandler<Query, Result<ActivityDto>>
        {
        private readonly DataContext _context;
            // Constructor initializes the 'Handler' with the given database context.
        private readonly IMapper _mapper;
       
            public Handler(DataContext context, IMapper mapper )
            {
                _mapper = mapper;
                _context = context;
                
            }
            public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
            {   
                // Fetch the activity from the database using the ID from the request.
                var activity =  await _context.Activities
                .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                // Return a 'Result' object containing the fetched activity, indicating success.
                return Result<ActivityDto>.Success(activity);
            }
        }
    }
}