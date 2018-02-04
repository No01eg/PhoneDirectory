using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
  public class TcpModule
  {
    public static void SendMessageFromSocket(string messag,int port)
    {
      //Буфер для входящих данных
      byte[] bytes = new byte[1024];

      //Соединяемся с удаленным устройством

      //Устанавливаем удаленную точку для сокета
      IPHostEntry host = Dns.GetHostEntry("localhost");
      IPAddress ipAddr = host.AddressList[0];
      IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

      Socket sendSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      //Соединяем сокет с удаленной точкой
      sendSocket.Connect(ipEndPoint);

      byte[] msg = Encoding.UTF8.GetBytes("ADD ");
      //отправляем данные через сокет
      int byteCount = sendSocket.Send(msg);
      msg = Encoding.UTF8.GetBytes(messag);
      //отправляем данные через сокет
      byteCount = sendSocket.Send(msg);

      sendSocket.Shutdown(SocketShutdown.Both);
      sendSocket.Close();
    }
  }
}
