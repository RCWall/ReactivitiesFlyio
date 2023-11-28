
using Domain;
using FluentValidation;


namespace Application.Activities
{
    // 'ActivityValidator' is a class used to check if an 'Activity' object has all the necessary information filled in.
    public class ActivityValidator: AbstractValidator<Activity>
    {
        // Constructor: This sets up the rules for validating an 'Activity' when an instance of 'ActivityValidator' is created.
        public ActivityValidator()
        {
            // The following lines set up rules to check different parts (fields) of an 'Activity'.
            // Each 'RuleFor' line ensures that a specific field is not empty or missing.
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
        }
        
    }
}