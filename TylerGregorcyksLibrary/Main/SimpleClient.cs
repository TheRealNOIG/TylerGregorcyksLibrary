using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace TylerGregorcyksLibrary.Main
{
    public class SimpleClient
    {
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public int attemptsToConnectToServer = 0;
        public bool failedToConnectToServer = false;

        public void startClient(string ip, int port)
        {
            while (!clientSocket.Connected)
            {
                if (attemptsToConnectToServer <= 3)
                {
                    try
                    {
                        IPAddress ipAd = IPAddress.Parse(ip);
                        clientSocket.Connect(ipAd, port);
                    }
                    catch (SocketException e)
                    {
                        attemptsToConnectToServer++;
                    }
                }
                else { failedToConnectToServer = true; }
            }
        }

        public void sendMessage(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            clientSocket.Send(buffer);
        }

        public string sendAndReceiveMessage(string text) {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            clientSocket.Send(buffer);

            byte[] recieveBuf = new byte[3200];
            int rec = clientSocket.Receive(recieveBuf);
            byte[] data = new byte[rec];
            Array.Copy(recieveBuf, data, rec);
            return Encoding.ASCII.GetString(data);
        }

        public string receiveMessage()
        {
            byte[] recieveBuf = new byte[3200];
            int rec = clientSocket.Receive(recieveBuf);
            byte[] data = new byte[rec];
            Array.Copy(recieveBuf, data, rec);
            return Encoding.ASCII.GetString(data);
        }
    }
}
