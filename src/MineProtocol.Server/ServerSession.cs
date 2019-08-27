using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.Server
{
    public class ServerSession
    {
        private TcpClient _tcpClient = null;

        public ServerSession(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
        }

        public async Task Start()
        {

        }
    }
}
