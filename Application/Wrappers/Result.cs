using System;

namespace VG.CDF.Client.Application.Wrappers;

public class Result<T>
{
    public bool IsError { get; set; }
    
    public string Message { get; set; } = String.Empty;

    public T? ResultContent { get; set; }

    public Result(T? resultContent, string message)
    {
        ResultContent = resultContent;
        Message = message;
    }

    public Result(string message)
    {
        Message = message;
    }
    
    
}

public class Result
{
    public bool IsError { get; set; }
    
    public string Message { get; set; } = String.Empty;
    

    public Result()
    {
    }
}