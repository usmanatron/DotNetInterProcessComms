using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      // Assume all arguments passed in are just one big message
      var message = string.Join(" ", args);

      Console.WriteLine("Sending message: " + message);

      new NamedPipeServer().WriteToPipe(message);

      Console.WriteLine("Message Sent!");
      Console.WriteLine("Press any key to exit");
      Console.ReadLine();
    }
  }
}