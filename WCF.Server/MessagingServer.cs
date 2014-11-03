using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF.Common;

namespace WCF.Server
{
  /// <summary>
  /// This defines the WCF Server, which listens for messages.  An instance 
  /// of MessagingService is passed into the host, which wires up the 
  /// request to a concrete implementation.
  /// </summary>
  public class MessagingServer : IDisposable
  {
    private ServiceHost host;

    public MessagingServer()
    {
      var service = new MessagingService();
      var address = CommunicationCommon.GetServiceAddress;

      host = new ServiceHost(service.GetType(), new Uri(address));
      host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
      host.AddServiceEndpoint(typeof(IMessagingService), new BasicHttpBinding(), "");
      
      host.Open();
    }

    public void Dispose()
    {
      host.Close();
    }
  }
}