using System;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Client
{
  /// <summary>
  /// Handles the actual communication.
  /// The ChannelFactory object is used to do the actual communication.  
  /// </summary>
  public class MessagingClient
  {
    private ChannelFactory<IMessagingService> clientFactory;

    public MessagingClient() 
    {
      var address = new EndpointAddress(CommunicationCommon.GetServiceAddress);
      clientFactory = new ChannelFactory<IMessagingService>(new BasicHttpBinding(), address);
    }

    public void SendMessage(string message)
    {
      clientFactory.CreateChannel().SendMessage(DateTime.Now, System.Net.Dns.GetHostName(), message);
    }
  }
}