using System;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Client
{
  class HttpMessagingClient : MessagingClient
  {
    protected override void SetupFactory()
    {
      var address = new EndpointAddress(CommunicationCommon.HttpServiceEndpoint);
      clientFactory = new ChannelFactory<IMessagingService>(new BasicHttpBinding(), address);
    }
  }
}