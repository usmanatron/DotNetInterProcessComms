using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace WCF.Server
{
  /// <summary>
  /// The only thing we need to do is create an instance of the MessagingServer class (so
  /// that we can listen for client messages).  Otherwise nothing happens here and we just 
  /// spin to keep the application running.
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      var useMessageQueues = args.FirstOrDefault() == "msmq";

      if (useMessageQueues)
      {
        var server = new MsmqMessagingServer();
      }
      else
      {
        var server = new HttpMessagingServer();
      }
      
      Console.WriteLine("Service listening...");

      while(true)
      {
        Thread.Sleep(10 * 1000);
      }
    }
  }
}