using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ConnectCard;
using System.Data.Common;

namespace Server
{
  class DBModule
  {
    public static void PushDBData(PacketDat pcd)
    {
      String connectionString = "Server=localhost;Port=5432;User=postgres;Password=1;Database=PhoneDirDB;";
      NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
      npgSqlConnection.Open();
      Console.WriteLine("Соединение с БД открыто");
      string data = string.Format(@"INSERT INTO dbphone(NAME, PHONENUM, EMAIL) VALUES ('{0}','{1}','{2}')",
        pcd.cName, pcd.cPhone, pcd.cMail);
      NpgsqlCommand npgSqlCommand = new NpgsqlCommand(data, npgSqlConnection);
      int count = npgSqlCommand.ExecuteNonQuery();
      if (count == 1)
        Console.WriteLine("Запись вставлена");
      else
        Console.WriteLine("Не удалось вставить новую записаь");
      npgSqlConnection.Close();
      //Console.ReadKey(true);
    }

    public static NpgsqlDataReader PullDBData(PacketDat pcd)
    {
      String connectionString = "Server=localhost;Port=5432;User=postgres;Password=1;Database=PhoneDirDB;";
      NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
      npgSqlConnection.Open();
      Console.WriteLine("Соединение с БД открыто");
      string data = string.Format(@"SELECT * FROM dbphone WHERE NAME LIKE '%{0}%'", pcd.cName);
      NpgsqlCommand npgSqlCommand = new NpgsqlCommand(data, npgSqlConnection);
      NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
      return npgSqlDataReader;
      /*if (npgSqlDataReader.HasRows)
      {
        Console.WriteLine("Таблица: example");
        Console.WriteLine("id value");
        foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
          Console.WriteLine(dbDataRecord["name"] + "   " + dbDataRecord["phonenum"] + "   " + dbDataRecord["email"]);
      }
      else
        Console.WriteLine("Запрос не вернул строк");*/

    }
  }
}
