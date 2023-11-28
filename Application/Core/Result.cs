

namespace Application.Core
{
    // 'Result<T>' is a generic class used to represent the outcome of an operation, where 'T' can be any type. 
    public class Result<T>
    {   
        // 'IsSuccess' indicates whether the operation was successful.
        public bool IsSuccess { get; set; }
        
        // 'Value' holds the successful result of the operation if 'IsSuccess' is true.
        public T Value { get; set; }
        
        // 'Error' contains the error message if the operation failed (i.e., if 'IsSuccess' is false).
        public string Error { get; set; }

        // 'Success' is a static method to create a successful result, taking 'value' as the successful return data.
        public static Result<T> Success(T value) => new Result<T> {IsSuccess = true, Value = value};
        
        // 'Failure' is a static method to create a failed result, taking 'error' as the error message.
        public static Result<T> Failure(string error) => new Result<T> {IsSuccess = false, Error = error};
    }
}