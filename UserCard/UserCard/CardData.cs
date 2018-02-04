using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public byte[] ToBytes()
    {
      //Преобразуем данные в массив байт
      //byte[] string
    }
  }
}
