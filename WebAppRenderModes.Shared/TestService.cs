namespace WebAppRenderModes.Shared;

public class TestService
{
    private string _testMessage = "Not Set";
    
    public void SetTestMessage(string message)
    {
        _testMessage = message;
    }

    public string GetTestMessage()
    {
        return _testMessage;
    }
}