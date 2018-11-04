using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        private System.IO.BinaryReader recv;
        private System.IO.BinaryWriter send;

        public Client(string host, int port)
        {
            System.Net.Sockets.TcpClient client =
                new System.Net.Sockets.TcpClient();
            client.Connect(host, port);
            System.Net.Sockets.NetworkStream stream = client.GetStream();

            this.recv = new System.IO.BinaryReader(stream);
            this.send = new System.IO.BinaryWriter(stream);
        }
        ~Client () {
            if (this.recv != null) this.recv.Close();
            if (this.send != null) this.send.Close();
        }
        public void Send(string message) {
            try {
                this.send.Write(message);
            }
            catch (Exception e) { }
        }
        public string Recv() {
            try {
                return this.recv.ReadString();
            }
            catch (Exception e) { return null; }
        }
    }
}
