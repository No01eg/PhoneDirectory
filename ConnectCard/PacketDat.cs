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

  public class PacketDat
  {
    public string cName { get; set; }
    public string cPhone { get; set; }
    public string cMail { get; set; }

    /*
     * Преобразуем наш объект в массив байт
     */
    public byte[] ToByte(cmdType cmd)
    {
      byte cmdB = (byte)cmd;
      string data = string.Format("{0};{1};{2}", cName, cPhone, cMail);
      byte[] datB = Encoding.UTF8.GetBytes(data);

      var messageData = new byte[datB.Length + 1];
      using (var stream = new MemoryStream(messageData))
      {
        var writer = new BinaryWriter(stream);
        writer.Write(cmdB);//команда
        writer.Write(datB);//данные
        return messageData;
      }
    }

    public static PacketDat FromByte(out cmdType cmd, byte[] bytes)
    {
      using (var ms = new MemoryStream(bytes))
      {
        var br = new BinaryReader(ms);
        var CurrentObject = new PacketDat();
        cmd = (cmdType)br.ReadByte();
        string dataPre = Encoding.UTF8.GetString(br.ReadBytes(bytes.Length -1));
        dataPre = dataPre.Trim(null);
        string[] data = dataPre.Split(';');
        CurrentObject.cName = data[0];
        CurrentObject.cPhone = data[1];
        CurrentObject.cMail = data[2].TrimEnd('\0');
        return CurrentObject;
      }
    }
      
  }
}
