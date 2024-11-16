namespace WebAppRenderModes.Shared;

public abstract class ResponseBase
{
    public Exception? Exception { get; set; }
    
    public bool IsSuccess => Exception is null;
    
    protected ResponseBase()
    {
    }
    
    protected ResponseBase(Exception exception)
    {
        Exception = exception;
    }
}