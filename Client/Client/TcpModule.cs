using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ConnectCard;

namespace Client
{
  public class TcpModule
  {
    public static void SendMessageFromSocket(PacketDat pcd,cmdType cmd,int port)
    {
      //Буфер для входящих данных
      byte[] bytes = new byte[512];

      //Соединяемся с удаленным устройством

      //Устанавливаем удаленную точку для сокета
      IPHostEntry host = Dns.GetHostEntry("localhost");
      IPAddress ipAddr = host.AddressList[0];
      IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

      Socket sendSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      //Соединяем сокет с удаленной точкой
      sendSocket.Connect(ipEndPoint);

      byte[] msg = pcd.ToByte(cmd);
      //отправляем данные через сокет
      int byteCount = sendSocket.Send(msg);

      sendSocket.Shutdown(SocketShutdown.Both);
      sendSocket.Close();
    }
  }
}
