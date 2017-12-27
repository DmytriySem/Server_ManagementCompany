using DTOs_library;
using ServerBLL_ManagementCompany.Interfaces;
using ServerBLL_ManagementCompany.Realizations;
using ServerBLL_ManagementCompany.ServiceBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer_ManagementCompany
{
    class Program
    {
        private static IPAddress ip = IPAddress.Loopback;
        private static int port = 20000;
        private static ISaveUserCredentials saveCredentials = null;
        private const int buffSize = 2048;

        static void Main(string[] args)
        {
            string connStr = GetConnStrForThisMashine.GetConnStr();
            saveCredentials = new SaveUserCredentials(connStr);

            IPEndPoint endPoint = new IPEndPoint(ip, port);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string data = String.Empty;
            Socket socket = null;
            try
            {
                listener.Bind(endPoint);
                listener.Listen(0);

                while (true)
                {
                    byte[] myBuffer = new byte[buffSize];
                    Console.WriteLine("Waiting for connection...");

                    socket = listener.Accept();
                    while (true)
                    {
                        int receiveCount = socket.Receive(myBuffer);

                        if (receiveCount != 0)
                            break;
                    }

                    UserDTO userDTO = (UserDTO)DTOSerializerHelper.DTOSerializerHelper.DesirealizeDTO(myBuffer);

                    //have data -> send to DB                    
                    saveCredentials.SaveUserCredentials(userDTO);
                }
            }
            //catch (Exception ex)
            //{
            //    //Console.WriteLine($"Exception: {ex}");
            //}
            finally
            {
                socket.Shutdown(SocketShutdown.Receive);
                if (socket != null)
                    socket.Close();
            }
        }
    }
}
