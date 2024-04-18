using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ResponseFactory
{
    public static ResponseResult Ok()
    {
        return new ResponseResult
        {
            Message = "Succeeded",
<<<<<<< HEAD
            StatusCode = StatusCode.OK
=======
            StatusCode = StatusCode.OK,
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
        };
    }

    public static ResponseResult Ok(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Succeeded",
            StatusCode = StatusCode.OK
        };
    }

    public static ResponseResult Ok(object obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "Succeeded",
            StatusCode = StatusCode.OK
        };
    }

    public static ResponseResult Error(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Failed",
            StatusCode = StatusCode.ERROR
        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Not found",
            StatusCode = StatusCode.NOT_FOUND
        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Already exists",
            StatusCode = StatusCode.EXISTS
        };
    }
}
