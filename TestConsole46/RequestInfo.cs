
namespace TestConsole46
{
    public class RequestInfo
    {
        private string host;
        private string port;
        private int retryCount;

        public string Host { get => host; }
        public string Port { get => port; }
        public int RetryCount { get => retryCount; }

        public RequestInfo(string url, string port, int retryCount = 0)
        {
            this.host = url;
            this.port = port;
            this.retryCount = retryCount;
        }
    }
}
