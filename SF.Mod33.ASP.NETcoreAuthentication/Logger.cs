namespace SF.Mod33.ASP.NETcoreAuthentication;

public class Logger : ILogger
{
	private string _eventFilePath;
	private string _errorFilePath;

	public void WriteEvent(string eventMessage)
	{
		string logString = $"{DateTime.Now.ToString()}: {eventMessage}{Environment.NewLine}";
		File.AppendAllTextAsync(_eventFilePath, logString);
		Console.WriteLine(logString);
	}

	public void WriteError(string errorMessage)
	{
		string logString = $"{DateTime.Now.ToString()}: {errorMessage}{Environment.NewLine}";
		File.AppendAllTextAsync(_errorFilePath, logString);
		Console.WriteLine(logString);
	}

	public Logger()
	{
		SetUp();
	}

	private void SetUp()
	{
	    string date = DateTime.Now.ToString("yyyyMMddHHmmss");	
		string rootPath = AppDomain.CurrentDomain.BaseDirectory;
		var logsFolder = Directory.CreateDirectory(Path.Combine(rootPath, $"{date}_Logs"));
		_eventFilePath = Path.Combine(logsFolder.FullName, "events.txt");
		_errorFilePath = Path.Combine(logsFolder.FullName, "errors.txt");
	}
}
