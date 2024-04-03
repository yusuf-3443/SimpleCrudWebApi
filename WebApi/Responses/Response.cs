using System.Net;

namespace WebApi.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Error { get; set; }
    public T? Data { get; set; }

    public Response(HttpStatusCode statusCode, string error, T data)
    {
        StatusCode = (int)statusCode;
        Error.Add(error);
        Data = data;
    }

    public Response(HttpStatusCode statusCode, List<string> error, T data)
    {
        StatusCode = (int)statusCode;
        Error = error;
        Data = data;
    }

    public Response(HttpStatusCode statusCode,string error)
    {
        StatusCode = (int)statusCode;
        Error.Add(error);
    }

    public Response(HttpStatusCode statusCode,List<string> error)
    {
        StatusCode = (int)statusCode;
        Error = error;
    }

    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
}