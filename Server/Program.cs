using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ConnectCard;
using Npgsql;
using System.Data.Common;


namespace Server
{
  class Program
  {
    static void Main(string[] args)
    {
      PacketDat pcd = new PacketDat();
      cmdType cmd;
      //Устанавливаем для сокета локальную конечную точку
      IPHostEntry iPHost = Dns.GetHostEntry("localhost");
      IPAddress ipAddr = iPHost.AddressList[0];
      IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);//порт 11000

      //Создаем сокет TCP/IP
      Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      //назначаем сокет локальной конечной точке и слушаем входящие сокеты
      try
      {
        sListener.Bind(ipEndPoint);
        sListener.Listen(10);

        //начинаем слушать соединение
        while (true)
        {
          Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

          //Программа приостанавливается, ожидая входящее соединение
          Socket handler = sListener.Accept();

          //мы дождались клиента, пытающегося с нами соединиться
          byte[] bytes = new byte[512];
          int bytesRec = handler.Receive(bytes);

          pcd = PacketDat.FromByte(out cmd, bytes);

          switch(cmd)
          {
            case cmdType.Add:
              DBModule.PushDBData(pcd);
              break;
            case cmdType.Search:
              NpgsqlDataReader npgSqlDataReader = DBModule.PullDBData(pcd);
              if (npgSqlDataReader.HasRows)
              {
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                  Console.WriteLine(dbDataRecord["name"] + "   " + dbDataRecord["phonenum"] + "   " + dbDataRecord["email"]);
                }
              }
              else
                Console.WriteLine("Запрос не вернул строк");
              break;
            default:
              Console.WriteLine("ERROR: Неправильный тип");
              break;
          }
          //Показываем данные на консоли
          Console.WriteLine("Полученный текст:\n\n");
          Console.WriteLine("{0}\n{1}\n{2}\n",pcd.cName,pcd.cPhone,pcd.cMail);

          //отправляем ответ клиенту
          /*string reply = "Спасибо за запрос в " + data.Length.ToString() + " символов";
          byte[] msg = Encoding.UTF8.GetBytes(reply);
          handler.Send(msg);*/

          if (pcd.cName.IndexOf("<TheEnd>") > -1)
          {
            Console.WriteLine("Сервер завершил соединение с клиентом");
            break;
          }

          handler.Shutdown(SocketShutdown.Both);
          handler.Close();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      finally
      {
        Console.ReadLine();
      }
    }
  }
}
