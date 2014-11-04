using System;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Client
{
  class MsmqMessagingClient : MessagingClient
  {
    protected override void SetupFactory()
    {
      var address = new EndpointAddress(CommunicationCommon.MsmqServiceEndpoint);
      clientFactory = new ChannelFactory<IMessagingService>(new NetMsmqBinding(NetMsmqSecurityMode.None), address);
    }
  }
}