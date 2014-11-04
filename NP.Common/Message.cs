using System;

namespace NP.Common
{
  /// <summary>
  /// Encapsulates a message.
  /// </summary>
  [Serializable]
  public class Message
  {
    public string Server { get; set; }
    public string Summary { get; set; }
  }
}
