using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF.Common;

namespace WCF.Server
{
  class HttpMessagingServer : MessagingServer
  {
    protected override void SetupDependencies()
    {
    }

    protected override string GetAddress()
    {
      return CommunicationCommon.HttpServiceEndpoint;
    }

    protected override void AddServiceEndpoint()
    {
      host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
      host.AddServiceEndpoint(typeof(IMessagingService), new BasicHttpBinding(), "");
    }
  }
}
