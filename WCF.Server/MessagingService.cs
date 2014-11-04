using System;
using WCF.Common;

namespace WCF.Server
{
  /// <summary>
  /// Actually implements the ServiceContract we specified in WCF.Common.
  /// This is where we actually specify what happens when the method is invoked.
  /// </summary>
  class MessagingService : IMessagingService
  {
    public void SendMessage(DateTime timestamp, string sender, string message)
    {
      Console.WriteLine("Message received from " + sender + " at " + timestamp);
      Console.WriteLine("Message: " + message);
    }
  }
}