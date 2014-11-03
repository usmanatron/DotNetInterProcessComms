using System;

namespace WCF.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      // Assume all arguments passed in are just one big message
      var message = string.Join(" ", args);

      Console.WriteLine("Sending message: " + message);

      new MessagingClient().SendMessage(message);

      Console.WriteLine("Message Sent!");
      Console.WriteLine("Press any key to exit");
      Console.ReadLine();
    }
  }
}
