using System;
using System.ServiceModel;

namespace WCF.Common
{
  /// <summary>
  /// This defines what methods can be passed from Client to Server.
  /// Both sides need this class to build the communication tunnel 
  /// and (additionally for the Server) to actually implement the methods.
  /// </summary>
  [ServiceContract]
  public interface IMessagingService
  {
    [OperationContract]
    void SendMessage(DateTime timestamp, string sender, string message);
  }
}