using System;
using System.IO;
using System.IO.Pipes;
using NP.Common;
using System.Net;
using System.Xml.Serialization;

namespace NP.Client
{
  /// <summary>
  /// Implements the Named Pipe server and pushes the data across
  /// </summary>
  /// <remarks>
  /// As can be seen below, we create a Named Pipe Server instance here (in the client).
  /// This may seem a bit strange, but the dea here is for the server to poll for a message on this pipe.
  /// </remarks>
  class NamedPipeServer
  {
    public void WriteToPipe(string messageSummary)
    {
      var message = new Message { Timestamp = DateTime.Now, Server = Dns.GetHostName(), Summary = messageSummary };

      var namedPipeServer = new NamedPipeServerStream(CommunicationCommon.NamedPipeInstance, PipeDirection.InOut);
      namedPipeServer.WaitForConnection();

      using (var writer = new StreamWriter(namedPipeServer))
      using (var serialiserStream = new StringWriter())
      {
        var serialiser = new XmlSerializer(typeof(Message));
        serialiser.Serialize(writer, message);
      }
    }
  }
}