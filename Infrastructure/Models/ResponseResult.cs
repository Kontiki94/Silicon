namespace Infrastructure.Models;

<<<<<<< HEAD

public enum StatusCode
{
    OK = 200,
    ERROR = 400,
    NOT_FOUND = 404,
    EXISTS = 409
}
public class ResponseResult
{
    public StatusCode StatusCode { get; set; }
    public object? ContentResult { get; set; }
    public string? Message { get; set; }

}
=======
    public enum StatusCode
    {
        OK = 200,
        ERROR = 400,
        NOT_FOUND = 404,
        EXISTS = 409
    }

    public class ResponseResult
    {
        public StatusCode StatusCode { get; set; }
        public object? ContentResult { get; set; }
        public string? Message { get; set; }
    }

>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
