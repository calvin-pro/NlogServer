using NlogServer;
using System;

namespace TestlogServer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogServer.WriteInfo("this info");
            LogServer.WriteError("this Error");
            LogServer.WriteDebug("this Debug");
            LogServer.WriteFatal("this Fatal");
        }
    }
}
