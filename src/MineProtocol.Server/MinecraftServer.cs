using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MineProtocol.Server
{
    public class MinecraftServer
    {
        private IPEndPoint _localEndPoint = null;

        private TcpListener _tcpListener = null;

        public MinecraftServer()
        {
            _localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 25565);
        }

        public MinecraftServer(IPEndPoint endPoint)
        {
            _localEndPoint = endPoint;
        }

        public async Task Start()
        {
            try
            {
                // TcpListener server = new TcpListener(port);
                _tcpListener = new TcpListener(_localEndPoint);

                // Start listening for client requests.
                _tcpListener.Start();
                while (true)
                {
                    var connection = await _tcpListener.AcceptTcpClientAsync();
                    await DispatchIncomingClient(connection);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                _tcpListener.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        public async Task DispatchIncomingClient(TcpClient tcpClient)
        {
            ServerSession session = new ServerSession(tcpClient);
            await session.Start();
        }
    }
}
