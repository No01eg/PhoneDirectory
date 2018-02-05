using System.IO;

namespace UserCard
{
  public class CardData
  {
    public string cmd { get; set; }
    private int cmdFieldLenght { get; set; }

    public string dataName { get; set; }
    private int dataNameFieldLenght { get; set; }

    public string dataPhone { get; set; }
    private int dataPhoneFieldLenght { get; set; }

    public string dataMail { get; set; }
    private int dataMailFieldLenght { get; set; }

    /*
     * вычисляем значения полей для каждого по отдельности и затем сумма байт
     */
    public int GetLenght()
    {
      cmdFieldLenght = cmd.Length;
      dataNameFieldLenght = dataName.Length;
      dataPhoneFieldLenght = dataPhone.Length;
      dataMailFieldLenght = dataMail.Length;
      return cmdFieldLenght + dataMailFieldLenght + dataPhoneFieldLenght + dataMailFieldLenght;
    }

    /*
     * Конвертируем объект в массив байт
     */
    public byte[] ToBytes()
    {
      var Messagedata = new byte[this.GetLenght() + 4 * sizeof(int)]; // длина строк + 4 позиции int для хранения длин строк

      using (var stream = new MemoryStream(Messagedata))
      {
        var writer = new BinaryWriter(stream);
        writer.Write(cmdFieldLenght);//длина команды
        writer.Write(cmd);//команда
        writer.Write(dataNameFieldLenght);//длина имени
        writer.Write(dataName);//имя
        writer.Write(dataPhoneFieldLenght);
        writer.Write(dataPhone);
        writer.Write(dataMailFieldLenght);
        writer.Write(dataMail);
        return Messagedata;
      }
    }

    /*
     * Обратная конвертация массива в объект
     */
    public CardData FromBytes(byte[] bytes)
    {
      using (var ms = new MemoryStream(bytes))
      {
        var br = new BinaryReader(ms);
        var currentObject = new CardData();
        currentObject.cmdFieldLenght = br.ReadInt32();
        currentObject.cmd = br.ReadBytes(currentObject.cmdFieldLenght).ToString();

        currentObject.dataNameFieldLenght = br.ReadInt32();
        currentObject.dataName = br.ReadBytes(currentObject.dataNameFieldLenght).ToString();

        currentObject.dataPhoneFieldLenght = br.ReadInt32();
        currentObject.dataPhone = br.ReadBytes(currentObject.dataPhoneFieldLenght).ToString();

        currentObject.dataMailFieldLenght = br.ReadInt32();
        currentObject.dataMail = br.ReadBytes(currentObject.dataMailFieldLenght).ToString();

        return currentObject;
      }
    }
  }
}
