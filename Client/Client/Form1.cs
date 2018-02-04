using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
      try
      {
        TcpModule.SendMessageFromSocket(tbSearchText.Text,11000);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Проблема соединения");
      }
    }

    private void bAdd_Click(object sender, EventArgs e)
    {
      dataGridView1.ColumnCount = 2;
      dataGridView1.RowCount = 4;
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
