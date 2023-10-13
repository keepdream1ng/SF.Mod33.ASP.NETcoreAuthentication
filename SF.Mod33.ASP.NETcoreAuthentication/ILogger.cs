namespace SF.Mod33.ASP.NETcoreAuthentication
{
	public interface ILogger
	{
		void WriteError(string errorMessage);
		void WriteEvent(string eventMessage);
	}
}