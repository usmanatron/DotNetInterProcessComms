using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using DNR.Common;
using System.Net;

namespace DNR.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var message = string.Join(" ", args);
      
      var channel = new TcpChannel();
      ChannelServices.RegisterChannel(channel, false);

      Console.WriteLine("Sending message: " + message);

      SendMessage(message);
      
      Console.WriteLine("Message Sent!");
      Console.WriteLine("Press any key to exit");
      Console.ReadLine();
    }

    private static void SendMessage(string message)
    {
      Type requiredType = typeof(IMessagingService);
      var remoteObject = (IMessagingService)Activator.GetObject(requiredType, "tcp://localhost:9998/MessagingService");
      remoteObject.SendMessage(Dns.GetHostName(), message); 
    }
  }
}