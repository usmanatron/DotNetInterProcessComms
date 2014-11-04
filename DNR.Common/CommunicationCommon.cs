namespace DNR.Common
{
  public static class CommunicationCommon
  {
    public static string CommunicationUri
    {
      get
      {
        return @"tcp://localhost:" + TcpPort + "/" + ServiceName;
      }
    }

    public static int TcpPort
    {
      get
      {
        return 9998;
      }
    }

    public static string ServiceName
    {
      get
      {
        return "MessagingService";
      }
    }

  }
}
