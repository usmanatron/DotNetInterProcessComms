using System;
using System.Messaging;
using MSMQ.Common;
using System.Net;

namespace MSMQ.Client
{
  /// <summary>
  /// Sends the MSMQ Message.  Note that the MSMQ Server component must
  /// be installed on your machine prior to this working!
  /// </summary>
  class MessagingClient
  {
    public void SendMessage(string messageSummary)
    {
      var message = new MSMQ.Common.Message { Server = Dns.GetHostName(), Summary = messageSummary };
      var messageQueue = new MessageQueue(CommunicationCommon.MessageQueueName);
      messageQueue.Send(message);
    }
  }
}