using System;
using System.Linq;

namespace WCF.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      bool useMessageQueues;
      string message;

      // Assume all arguments passed in are just one big message (unless
      // the first argument is msmq - if so, ignore that!
      if (args.FirstOrDefault() == "msmq")
      {
        useMessageQueues = true;
        message = string.Join(" ", args.Skip(1));
      }
      else
      {
        useMessageQueues = false;
        message = string.Join(" ", args);

      }

      Console.WriteLine("Sending message: " + message);

      if (useMessageQueues)
      {
        new MsmqMessagingClient().SendMessage(message);
      }
      else
      {
        new HttpMessagingClient().SendMessage(message);
      }

      Console.WriteLine("Message Sent!");
      Console.WriteLine("Press any key to exit");
      Console.ReadLine();
    }
  }
}