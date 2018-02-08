using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ConnectCard;
using System.Windows.Forms;

namespace Client
{
  public class TcpModule
  {
    public static List<PacketDat> SendMessageFromSocket(PacketDat pcd,cmdType cmd,int port)
    {
      //Буфер для входящих данных
      byte[] bytes = new byte[512];
      List<PacketDat> pcdL = new List<PacketDat>();
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
      bool getAll = false;
      do
      {
        // Получаем ответ от сервера
        sendSocket.Receive(bytes);

        pcd = PacketDat.FromByte(out cmd, bytes);

        switch (cmd)
        {
          case cmdType.Add_OK:
            MessageBox.Show("Запись добавлена", "Успех");
            pcdL = null;
            break;
          case cmdType.Srch_OK:
            getAll = true;
            pcdL.Add(pcd);
            break;
          case cmdType.Srch_FAIL:
            if(getAll) MessageBox.Show("Поиск завершен");
            else MessageBox.Show("Поиск не дал результатов");
            getAll = false;
            break;
          default:
            MessageBox.Show("Команда не существует");
            pcdL = null;
            break;
        }
      }
      while (getAll);

      sendSocket.Shutdown(SocketShutdown.Both);
      sendSocket.Close();
      return pcdL;
    }
  }
}
