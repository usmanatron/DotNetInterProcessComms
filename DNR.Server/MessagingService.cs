using System;
using DNR.Common;

namespace DNR.Server
{
  class MessagingService : MarshalByRefObject, IMessagingService
  {
    public void SendMessage(string sender, string message)
    {
      Console.WriteLine("Message received from " + sender + " at " + DateTime.Now);
      Console.WriteLine("Message: " + message);
    }
  }
}