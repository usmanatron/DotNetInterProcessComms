namespace WCF.Common
{
  /// <summary>
  /// Common stuff that needs to be shared between both Client and 
  /// Server.  In this case, the Url is needed by both (so the client 
  /// knows where to send messages, and the server knows what to 
  /// listen to!).
  /// </summary>
  /// <remarks>
  /// In this case, for the purpose of demonstration, localhost has 
  /// been hard-coded into the address.  In practice, you can put the
  /// hostname of the designated server here, which will also 
  /// allow for communication through a network (firewall permitting!).
  /// </remarks>
  public static class CommunicationCommon
  {
    public static string GetServiceAddress
    {
      get
      {
        return @"http://localhost/MessagingService";
      }
    }
  }
}
