using System;
using System.Net;
using System.Threading.Tasks;
using MineProtocol.Server;

namespace MineProtocol.Demo
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            return StartUp().Result;
        }

        private static async Task<int> StartUp()
        {
            MinecraftServer server = new MinecraftServer();
            await server.Start();

            return 0;
        }
    }
}
