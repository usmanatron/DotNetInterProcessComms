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
  public abstract class MessagingServer : IDisposable
  {
    protected ServiceHost host;

    public MessagingServer()
    {
      SetupDependencies();

      var service = new MessagingService();
      var address = GetAddress();
      
      host = new ServiceHost(service.GetType(), new Uri(address));
      AddServiceEndpoint();
      
      host.Open();
    }

    protected abstract void SetupDependencies();

    protected abstract string GetAddress();

    protected abstract void AddServiceEndpoint();

    public void Dispose()
    {
      host.Close();
    }
  }
}