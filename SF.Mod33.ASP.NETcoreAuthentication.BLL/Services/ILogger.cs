namespace SF.Mod33.ASP.NETcoreAuthentication.BLL;
public interface ILogger
{
	void WriteError(string errorMessage);
	void WriteEvent(string eventMessage);
}