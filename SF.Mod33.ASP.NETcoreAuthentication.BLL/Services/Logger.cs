namespace SF.Mod33.ASP.NETcoreAuthentication.BLL;

public class Logger : ILogger
{
	private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
	private string _logDirectory;
	public Logger()
	{
		_logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

		if (!Directory.Exists(_logDirectory))
			Directory.CreateDirectory(_logDirectory);

	}

	public void WriteEvent(string eventMessage)
	{
		string logString = $"{DateTime.Now.ToString()}: {eventMessage}";
		Console.WriteLine(logString);
		_lock.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(_logDirectory + "events.txt", append: true))
                {
                    writer.WriteLine(logString);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }	
	}

	public void WriteError(string errorMessage)
	{
		string logString = $"{DateTime.Now.ToString()}: {errorMessage}";
		Console.WriteLine(logString);
		_lock.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(_logDirectory + "errors.txt", append: true))
                {
                    writer.WriteLine(logString);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }	
	}

}
