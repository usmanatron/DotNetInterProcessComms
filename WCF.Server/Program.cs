using System;
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
    private static MessagingServer server;

    static void Main(string[] args)
    {
      server = new MessagingServer();
      Console.WriteLine("Service listening...");

      while(true)
      {
        Thread.Sleep(10 * 1000);
      }
    }
  }
}