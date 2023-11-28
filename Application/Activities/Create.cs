//purpose: create a new activity
using Application.Core;
using FluentValidation;
using MediatR;
using Persistence;


namespace Application.Activities
{
    // 'Create' is a class containing all the logic to create a new activity.
    public class Create
    {
        // 'Command' is a blueprint for the information needed to create an activity.
        public class Command : IRequest<Result<Unit>>
        {
            // This is where the details of the activity are stored.
            public Domain.Activity Activity { get; set; }        
        }
        
        // This class checks if the information in 'Command' is correct before it is used.
        public class CommandValidator : AbstractValidator<Command>
        {
            // Constructor: This sets up the rules for validation when an instance is created.
            public CommandValidator()
            {
                // This line specifies that 'Activity' needs to be validated using specific rules defined in 'ActivityValidator'.
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        // 'Handler' is responsible for taking the 'Command' and doing something with it, like saving it in a database.
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            // This is a tool to interact with the database.
            private readonly DataContext _context;
            
            // Constructor: This is like setting up the Handler, telling it about the database tool 'DataContext'.
            public Handler(DataContext context)
            {
                _context = context;
            }

            // This method is where the action happens when a 'Command' is received.
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // Add the new activity to the database.
                _context.Activities.Add(request.Activity);

                // Try to save changes in the database. If successful, 'result' is true; otherwise, it's false.
                var result = await _context.SaveChangesAsync() > 0;

                // If saving to the database failed, report back that creating the activity failed.
                if (!result) return Result<Unit>.Failure("Failed to create activity");
                
                // If everything went well, report back success.
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}