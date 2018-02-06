using System.Text;
using System.IO;

namespace ConnectCard
{
  public enum cmdType {
    Add = 1,    //Добавить запись  
    Search,     //Выполнить поиск
    Delete,     //Удалить запись
    Srch_OK,    //Поиск дал результат
    Srch_FAIL,  //Ничего не найдено
    Add_OK,     //Запись добавлена
    Del_OK      //Запись удалена
  }

  public class Packet
  {
    string cName { get; set; }
    string cPhone { get; set; }
    string cMail { get; set; }

    /*
     * Преобразуем наш объект в массив байт
     */
    public byte[] ToByte(cmdType cmd, Packet pct)
    {
      byte cmdB = (byte)cmd;
      string data = string.Format("{0};{1};{2}",pct.cName,pct.cPhone,pct.cMail);
      byte[] datB = Encoding.UTF8.GetBytes(data);

      var messageData = new byte[data.Length + 1];
      using (var stream = new MemoryStream(messageData))
      {
        var writer = new BinaryWriter(stream);
        writer.Write(datB);//команда
        writer.Write(data);//данные
        return messageData;
      }
    }

    public static Packet FromByte(out cmdType cmd, byte[] bytes)
    {
      using (var ms = new MemoryStream(bytes))
      {
        var br = new BinaryReader(ms);
        var CurrentObject = new Packet();
        cmd = (cmdType)br.ReadByte();
        string dataPre = Encoding.UTF8.GetString(br.ReadBytes(bytes.Length -1));
        string[] data = dataPre.Split(';');
        CurrentObject.cName = data[0];
        CurrentObject.cPhone = data[1];
        CurrentObject.cMail = data[2];
        return CurrentObject;
      }
    }
      
  }
}
