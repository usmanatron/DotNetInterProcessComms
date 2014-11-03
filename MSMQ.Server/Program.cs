using System;
using System.Collections.Generic;
using System.Threading;

namespace MSMQ.Server
{
  /// <summary>
  /// Unlike WCF, more work needs to be done here - we have to 
  /// manually check the queue and act on what we find there (whilst,
  /// in WCF, a new thread is spawned for the request).
  /// </summary>
  class Program
  {
    private static MessageParser parser;

    static void Main(string[] args)
    {
      parser = new MessageParser(new MessageAdministrator());
      Console.WriteLine("Service listening...");

      while(true)
      {
        var message = parser.GetNextMessage();
        if (message != null)
        {
          Console.WriteLine("Message received from " + message.Server + " at " + DateTime.Now);
          Console.WriteLine("Message: " + message.Summary);
        }
      }
    }
  }
}