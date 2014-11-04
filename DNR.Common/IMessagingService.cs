namespace DNR.Common
{
  /// <summary>
  /// This defines what methods can be passed from Client to Server.
  /// Both sides need this class to build the communication tunnel 
  /// and (additionally for the Server) to actually implement the methods.
  /// </summary>
  public interface IMessagingService
  {
    void SendMessage(string sender, string message);
  }
}