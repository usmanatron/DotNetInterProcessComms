using System;
using System.IO;
using System.IO.Pipes;
using System.Net;
using NP.Common;
using System.Xml.Serialization;

namespace NP.Server
{
  class NamedPipeClient
  {
    public Message TryGetMessage()
    {
      var namedPipeClient = new NamedPipeClientStream(Dns.GetHostName(), CommunicationCommon.NamedPipeInstance, PipeDirection.InOut);
      
      try
      {
        namedPipeClient.Connect(100);
      }
      catch (System.TimeoutException)
      {
        // Nobody at the end of the pipe - return nothing
        return null;
      }

      return ReadResponseFromPipe(namedPipeClient);
    }

    private Message ReadResponseFromPipe(NamedPipeClientStream namedPipe)
    {
      using (var reader = new StreamReader(namedPipe))
      {
        var deserialiser = new XmlSerializer(typeof (Message));
        return (Message) deserialiser.Deserialize(reader);
      }
    }
  }
}