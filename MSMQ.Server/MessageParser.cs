using System;
using System.Collections.Generic;
using System.IO;
using System.Messaging;
using MSMQ.Common;

namespace MSMQ.Server
{
  /// <summary>
  /// Wraps the MessageAdministrator.  Deals with taking the message and turning it into 
  /// a Message we can manipulate further.
  /// </summary>
  class MessageParser
  {
    private MessageAdministrator administrator;

    public MessageParser(MessageAdministrator administrator)
    {
      this.administrator = administrator;
    }

    public MSMQ.Common.Message GetNextMessage()
    {
      try
      {
        var message = administrator.Read();
        message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[1] { typeof(MSMQ.Common.Message) });
        return (MSMQ.Common.Message)message.Body;
      }
      catch
      {
        // failed to read => We assume there are no messages in the Queue
        return null;
      }
    }
  }
}
