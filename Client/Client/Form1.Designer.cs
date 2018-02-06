namespace Client
{
  partial class PhoneDir
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.rbNameSearch = new System.Windows.Forms.RadioButton();
      this.rbDescriptSearch = new System.Windows.Forms.RadioButton();
      this.bSearchStart = new System.Windows.Forms.Button();
      this.tbSearchText = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.bAdd = new System.Windows.Forms.Button();
      this.bDelete = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.usName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // rbNameSearch
      // 
      this.rbNameSearch.AutoSize = true;
      this.rbNameSearch.Checked = true;
      this.rbNameSearch.Cursor = System.Windows.Forms.Cursors.Hand;
      this.rbNameSearch.Location = new System.Drawing.Point(12, 41);
      this.rbNameSearch.Name = "rbNameSearch";
      this.rbNameSearch.Size = new System.Drawing.Size(102, 17);
      this.rbNameSearch.TabIndex = 0;
      this.rbNameSearch.TabStop = true;
      this.rbNameSearch.Text = "Поиск по ФИО";
      this.rbNameSearch.UseVisualStyleBackColor = true;
      // 
      // rbDescriptSearch
      // 
      this.rbDescriptSearch.AutoSize = true;
      this.rbDescriptSearch.Cursor = System.Windows.Forms.Cursors.Hand;
      this.rbDescriptSearch.Location = new System.Drawing.Point(120, 41);
      this.rbDescriptSearch.Name = "rbDescriptSearch";
      this.rbDescriptSearch.Size = new System.Drawing.Size(125, 17);
      this.rbDescriptSearch.TabIndex = 1;
      this.rbDescriptSearch.Text = "Поиск по описанию";
      this.rbDescriptSearch.UseVisualStyleBackColor = true;
      // 
      // bSearchStart
      // 
      this.bSearchStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bSearchStart.Cursor = System.Windows.Forms.Cursors.Hand;
      this.bSearchStart.Location = new System.Drawing.Point(378, 12);
      this.bSearchStart.Name = "bSearchStart";
      this.bSearchStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.bSearchStart.Size = new System.Drawing.Size(109, 23);
      this.bSearchStart.TabIndex = 2;
      this.bSearchStart.Text = "Поиск";
      this.bSearchStart.UseVisualStyleBackColor = true;
      this.bSearchStart.Click += new System.EventHandler(this.bSearchStart_Click);
      // 
      // tbSearchText
      // 
      this.tbSearchText.Location = new System.Drawing.Point(12, 12);
      this.tbSearchText.Name = "tbSearchText";
      this.tbSearchText.Size = new System.Drawing.Size(360, 20);
      this.tbSearchText.TabIndex = 3;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
      // 
      // bAdd
      // 
      this.bAdd.Cursor = System.Windows.Forms.Cursors.Hand;
      this.bAdd.Location = new System.Drawing.Point(266, 38);
      this.bAdd.Name = "bAdd";
      this.bAdd.Size = new System.Drawing.Size(106, 23);
      this.bAdd.TabIndex = 4;
      this.bAdd.Text = "Добавить запись";
      this.bAdd.UseVisualStyleBackColor = true;
      this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
      // 
      // bDelete
      // 
      this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bDelete.Cursor = System.Windows.Forms.Cursors.Hand;
      this.bDelete.Enabled = false;
      this.bDelete.Location = new System.Drawing.Point(378, 38);
      this.bDelete.Name = "bDelete";
      this.bDelete.Size = new System.Drawing.Size(109, 23);
      this.bDelete.TabIndex = 5;
      this.bDelete.Text = "Удалить запись";
      this.bDelete.UseVisualStyleBackColor = true;
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usName,
            this.phone,
            this.mail});
      this.dataGridView1.Location = new System.Drawing.Point(12, 67);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(475, 47);
      this.dataGridView1.TabIndex = 6;
      // 
      // usName
      // 
      this.usName.HeaderText = "ФИО";
      this.usName.Name = "usName";
      this.usName.Width = 160;
      // 
      // phone
      // 
      this.phone.HeaderText = "Номер";
      this.phone.Name = "phone";
      this.phone.Width = 120;
      // 
      // mail
      // 
      this.mail.HeaderText = "Почта";
      this.mail.Name = "mail";
      this.mail.Width = 130;
      // 
      // PhoneDir
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(499, 117);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.bDelete);
      this.Controls.Add(this.bAdd);
      this.Controls.Add(this.tbSearchText);
      this.Controls.Add(this.bSearchStart);
      this.Controls.Add(this.rbDescriptSearch);
      this.Controls.Add(this.rbNameSearch);
      this.MaximumSize = new System.Drawing.Size(1000, 300);
      this.MinimumSize = new System.Drawing.Size(400, 155);
      this.Name = "PhoneDir";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Телефонный справочник (клиент)";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbNameSearch;
    private System.Windows.Forms.RadioButton rbDescriptSearch;
    private System.Windows.Forms.Button bSearchStart;
    protected System.Windows.Forms.TextBox tbSearchText;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.Button bAdd;
    private System.Windows.Forms.Button bDelete;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn usName;
    private System.Windows.Forms.DataGridViewTextBoxColumn phone;
    private System.Windows.Forms.DataGridViewTextBoxColumn mail;
  }
}

