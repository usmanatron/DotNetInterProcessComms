using System;
using System.Text;

namespace NP.Server
{
  /// <summary>
  /// Similarly to MSMQ, we need to try and get a message and, 
  /// if we're successful, do something with it directly ourselves.
  /// </summary>
  class Program
  {
    private static NamedPipeClient client;

    static void Main(string[] args)
    {
      client = new NamedPipeClient();
      Console.WriteLine("Service listening...");

      while(true)
      {
        var message = client.TryGetMessage();
        if (message != null)
        {
          Console.WriteLine("Message received from " + message.Server + " at " + DateTime.Now);
          Console.WriteLine("Message: " + message.Summary);
        }
      }
    }
  }
}