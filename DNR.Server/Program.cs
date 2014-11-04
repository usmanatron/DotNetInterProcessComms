using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using DNR.Common;

namespace DNR.Server
{
  class Program
  {
    static void Main(string[] args)
    {
      var channel = new TcpChannel(CommunicationCommon.TcpPort);
      ChannelServices.RegisterChannel(channel, false);
      RemotingConfiguration.RegisterWellKnownServiceType(typeof(MessagingService), CommunicationCommon.ServiceName, WellKnownObjectMode.SingleCall);

      Console.WriteLine("Service listening...");

      while (true)
      {
        Thread.Sleep(10 * 1000);
      }
    }
  }
}
