using System;
using System.Messaging;
using System.ServiceModel;
using WCF.Common;

namespace WCF.Server
{
  class MsmqMessagingServer : MessagingServer
  {
    protected override void SetupDependencies()
    {
      if (!MessageQueue.Exists(CommunicationCommon.MsmqQueueName))
      {
        MessageQueue.Create(CommunicationCommon.MsmqQueueName, true);
      }
    }

    protected override string GetAddress()
    {
      return CommunicationCommon.MsmqServiceEndpoint;
    }

    protected override void AddServiceEndpoint()
    {
      host.AddServiceEndpoint(typeof(IMessagingService), new NetMsmqBinding(NetMsmqSecurityMode.None), "");
    }
  }
}
