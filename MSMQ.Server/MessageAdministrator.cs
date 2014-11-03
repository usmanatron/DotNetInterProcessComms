using System;
using System.Messaging;
using MSMQ.Common;

namespace MSMQ.Server
{
  /// <summary>
  /// Actually deals with manpulating and administering the Message Queue.
  /// This includes creating the queue and reading from it.
  /// </summary>
  class MessageAdministrator
  {
    public MessageAdministrator()
    {
      RecreateQueue();
      messageQueue = new MessageQueue(CommunicationCommon.MessageQueueName);
    }

    private void RecreateQueue()
    {
      if (MessageQueue.Exists(CommunicationCommon.MessageQueueName))
      {
        MessageQueue.Delete(CommunicationCommon.MessageQueueName);
      }
      MessageQueue.Create(CommunicationCommon.MessageQueueName);
    }
    
    public System.Messaging.Message Read()
    {
      lock (messageQueue)
      {
        return messageQueue.Receive(new TimeSpan(100));
      }
    }

    private static MessageQueue messageQueue;
  }
}