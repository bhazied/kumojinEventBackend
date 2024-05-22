using Kumojin.Events.Application.Common.Interfaces;

namespace Kumojin.Events.Application;

public class Result<T> : IResult<T>
{
    public T Data {get;set;}
    public string[] Errors {get;init;}
    public bool Succeeded {get;init;}
     public string ErrorMessage => string.Join(", ", Errors ?? new string[]{});

     public static Result<T> Failure(string[] errors)
     {
         return new Result<T>{Succeeded = false, Errors = errors.ToArray()};
     }

     public async static  Task<Result<T>> FailureAsync(string[] errors)
     {
        return await Task.FromResult(Failure(errors));
     }

     public static Result<T> Success(T data)
     {
         return new Result<T>{Succeeded = true, Data = data};
     }

     public async static  Task<Result<T>> SuccessAsync(T data)
     {
        return await Task.FromResult(Success(data));
     }

}
