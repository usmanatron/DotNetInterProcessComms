using System;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Client
{
  /// <summary>
  /// Handles the actual communication.
  /// The ChannelFactory object is used to do the actual communication.  
  /// </summary>
  public abstract class MessagingClient
  {
    protected ChannelFactory<IMessagingService> clientFactory;

    public MessagingClient() 
    {
      SetupFactory();
    }

    protected abstract void SetupFactory();

    public void SendMessage(string message)
    {
      clientFactory.CreateChannel().SendMessage(DateTime.Now, System.Net.Dns.GetHostName(), message);
    }
  }
}