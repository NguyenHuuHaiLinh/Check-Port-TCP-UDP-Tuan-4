using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace CheckPortTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("nhap port: ");
            n = int.Parse(Console.ReadLine());
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("172.18.2.103"), n);
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(ipe);
                    Console.WriteLine("TCP Port Open ");
                    tcpClient.Close();
                }
                catch(Exception)
                {
                    Console.WriteLine("TCP Port Close");
                }
            }
            //udp
           
            UdpClient udp = new UdpClient();
            udp.Connect(ipe);
            byte[] data = Encoding.ASCII.GetBytes("aaaaaaaa");
            udp.Send(data, data.Length);
            try
            {
                udp.Receive(ref ipe);
                Console.WriteLine("port udp mở");
                udp.Close();
            }
            catch(Exception)
            {
                Console.WriteLine("port udp đóng");
            }
            Console.ReadLine();
        }
    }
}
