using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectCard;

namespace Client
{
  
  public partial class PhoneDir : Form
  {
    public PhoneDir()
    {
      InitializeComponent();
    }

    private void bSearchStart_Click(object sender, EventArgs e)
    {
      if(tbSearchText.Text == "")//на случай если забыли ввесли ключ поиска
      {
        MessageBox.Show("\tВведите данные \nдля поиска карточки в базе","Внимание!");
        return;
      }
      //Соединяемся через соект с сервером и передаем ему данные
      PacketDat dataP = new PacketDat();
      dataP.cName = tbSearchText.Text;
      dataP.cPhone = " ";
      dataP.cMail = " ";
      dataGridView1.Rows.Clear();
      try
      {
        TcpModule.SendMessageFromSocket(dataP, cmdType.Search, 11000);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Проблема соединения");
      }
    }

    private void bAdd_Click(object sender, EventArgs e)
    {
      if(dataGridView1.Rows[0].Cells[0].Value == null || 
        dataGridView1.Rows[0].Cells[1].Value == null || 
        dataGridView1.Rows[0].Cells[2].Value == null)
      {
        MessageBox.Show("Не все ячейки заполнены","Внимание");
        return;
      }
      PacketDat dataP = new PacketDat();
      dataP.cName = (string)dataGridView1.Rows[0].Cells[0].Value;
      dataP.cPhone = (string)dataGridView1.Rows[0].Cells[1].Value;
      dataP.cMail = (string)dataGridView1.Rows[0].Cells[2].Value;
      try
      {
        TcpModule.SendMessageFromSocket(dataP, cmdType.Add, 11000);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Проблема соединения");
      }
      finally
      {
        dataGridView1.Rows.Clear();
      }
    }

    private void PhoneDir_FormClosing(object sender, FormClosingEventArgs e)
    {
      PacketDat dataP = new PacketDat();
      dataP.cName = "<TheEnd>";
      dataP.cPhone = " ";
      dataP.cMail = " ";
      //dataP.ToByte(cmdType.Add);
      try
      {
        TcpModule.SendMessageFromSocket(dataP, cmdType.Add, 11000);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Проблема соединения");
      }
    }
  }
}
