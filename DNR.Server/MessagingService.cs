using System;
using DNR.Common;

namespace DNR.Server
{
  class MessagingService : MarshalByRefObject, IMessagingService
  {
    public void SendMessage(DateTime timestamp, string sender, string message)
    {
      Console.WriteLine("Message received from " + sender + " at " + timestamp);
      Console.WriteLine("Message: " + message);
    }
  }
}