using Application.Dtos.Contracts;
using Application.Messaging;

public class ResultService<T> : IResultService<T> 
{
    public T Data { get; set; }
    public bool Sucess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public ResultService(bool sucess, string message, T data)
    {
        Sucess = sucess;
        Message = message;
        Data = data;
    }

    public ResultService(bool sucess, string message, List<string> errors)
    {
        Sucess = sucess;
        Message = message;
        Errors = errors;
    }

    public ResultService(bool sucess, string message, string error)
    {
        Sucess = sucess;
        Message = message;
        Errors.Add(error);
    }
}
