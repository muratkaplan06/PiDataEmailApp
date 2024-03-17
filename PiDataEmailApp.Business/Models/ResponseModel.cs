using System.Text.Json.Serialization;

namespace PiDataEmailApp.Business.Models;

public class ResponseModel<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    [JsonIgnore] 
    public int StatusCode { get; set; }

    public static Task<ResponseModel<T>> SuccessAsync(T data, int statusCode)
    {
        return Task.FromResult(new ResponseModel<T> { Data = data, StatusCode = statusCode });
    }

    public static ResponseModel<T> Success(T data, int statusCode)
    {
        return new ResponseModel<T> { Data = data, StatusCode = statusCode };
    }

    public static ResponseModel<T> Success(int statusCode)
    {
        return new ResponseModel<T> { StatusCode = statusCode };
    }

    public static ResponseModel<T> Fail(int statuscode, List<string> errors)
    {
        return new ResponseModel<T> { StatusCode = statuscode, Errors = errors };
    }

    public static ResponseModel<T> Fail(int statuscode, string error)
    {
        return new ResponseModel<T> { StatusCode = statuscode, Errors = new List<string> { error } };
    }

    public static Task<ResponseModel<T>> SuccessAsync(int statusCode)
    {
        return Task.FromResult(new ResponseModel<T> { StatusCode = statusCode });
    }

    public static Task<ResponseModel<T>> FailAsync(int statuscode, List<string> errors)
    {
        return Task.FromResult(new ResponseModel<T> { StatusCode = statuscode, Errors = errors });
    }

    public static Task<ResponseModel<T>> FailAsync(int statuscode, string error)
    {
        return Task.FromResult(
            new ResponseModel<T> { StatusCode = statuscode, Errors = new List<string> { error } });
    }
}