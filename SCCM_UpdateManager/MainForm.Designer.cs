namespace SCCM_UpdateManager
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fStatus = new System.Windows.Forms.StatusStrip();
            this.fStatusBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.fStatusCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.fPanelConnect = new System.Windows.Forms.GroupBox();
            this.fUserPasswordLabel = new System.Windows.Forms.Label();
            this.fUserNameLabel = new System.Windows.Forms.Label();
            this.fServerNameLabel = new System.Windows.Forms.Label();
            this.fConnect = new System.Windows.Forms.Button();
            this.fUserPassword = new System.Windows.Forms.TextBox();
            this.fUserName = new System.Windows.Forms.TextBox();
            this.fServerName = new System.Windows.Forms.TextBox();
            this.fPanelCompare = new System.Windows.Forms.GroupBox();
            this.fCreateNewList = new System.Windows.Forms.CheckBox();
            this.fCompare = new System.Windows.Forms.Button();
            this.fObject2 = new System.Windows.Forms.ComboBox();
            this.fObject1 = new System.Windows.Forms.ComboBox();
            this.fStatus.SuspendLayout();
            this.fPanelConnect.SuspendLayout();
            this.fPanelCompare.SuspendLayout();
            this.SuspendLayout();
            // 
            // fStatus
            // 
            this.fStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fStatusBlank,
            this.fStatusCopyright});
            this.fStatus.Location = new System.Drawing.Point(0, 284);
            this.fStatus.Name = "fStatus";
            this.fStatus.Size = new System.Drawing.Size(474, 22);
            this.fStatus.TabIndex = 17;
            this.fStatus.Text = "statusStrip1";
            // 
            // fStatusBlank
            // 
            this.fStatusBlank.Name = "fStatusBlank";
            this.fStatusBlank.Size = new System.Drawing.Size(228, 17);
            this.fStatusBlank.Spring = true;
            // 
            // fStatusCopyright
            // 
            this.fStatusCopyright.Name = "fStatusCopyright";
            this.fStatusCopyright.Size = new System.Drawing.Size(200, 17);
            this.fStatusCopyright.Text = "Copyright © 2011, Любимов Роман";
            // 
            // fPanelConnect
            // 
            this.fPanelConnect.Controls.Add(this.fUserPasswordLabel);
            this.fPanelConnect.Controls.Add(this.fUserNameLabel);
            this.fPanelConnect.Controls.Add(this.fServerNameLabel);
            this.fPanelConnect.Controls.Add(this.fConnect);
            this.fPanelConnect.Controls.Add(this.fUserPassword);
            this.fPanelConnect.Controls.Add(this.fUserName);
            this.fPanelConnect.Controls.Add(this.fServerName);
            this.fPanelConnect.Location = new System.Drawing.Point(12, 12);
            this.fPanelConnect.Name = "fPanelConnect";
            this.fPanelConnect.Size = new System.Drawing.Size(451, 105);
            this.fPanelConnect.TabIndex = 19;
            this.fPanelConnect.TabStop = false;
            this.fPanelConnect.Text = "Подключение";
            // 
            // fUserPasswordLabel
            // 
            this.fUserPasswordLabel.AutoSize = true;
            this.fUserPasswordLabel.Location = new System.Drawing.Point(254, 27);
            this.fUserPasswordLabel.Name = "fUserPasswordLabel";
            this.fUserPasswordLabel.Size = new System.Drawing.Size(45, 13);
            this.fUserPasswordLabel.TabIndex = 15;
            this.fUserPasswordLabel.Text = "Пароль";
            // 
            // fUserNameLabel
            // 
            this.fUserNameLabel.AutoSize = true;
            this.fUserNameLabel.Location = new System.Drawing.Point(134, 28);
            this.fUserNameLabel.Name = "fUserNameLabel";
            this.fUserNameLabel.Size = new System.Drawing.Size(103, 13);
            this.fUserNameLabel.TabIndex = 14;
            this.fUserNameLabel.Text = "Имя пользователя";
            // 
            // fServerNameLabel
            // 
            this.fServerNameLabel.AutoSize = true;
            this.fServerNameLabel.Location = new System.Drawing.Point(14, 28);
            this.fServerNameLabel.Name = "fServerNameLabel";
            this.fServerNameLabel.Size = new System.Drawing.Size(74, 13);
            this.fServerNameLabel.TabIndex = 13;
            this.fServerNameLabel.Text = "Имя сервера";
            // 
            // fConnect
            // 
            this.fConnect.Location = new System.Drawing.Point(17, 69);
            this.fConnect.Name = "fConnect";
            this.fConnect.Size = new System.Drawing.Size(100, 23);
            this.fConnect.TabIndex = 12;
            this.fConnect.Text = "Подключиться";
            this.fConnect.UseVisualStyleBackColor = true;
            this.fConnect.Click += new System.EventHandler(this.fConnect_Click);
            // 
            // fUserPassword
            // 
            this.fUserPassword.Location = new System.Drawing.Point(257, 43);
            this.fUserPassword.Name = "fUserPassword";
            this.fUserPassword.PasswordChar = '*';
            this.fUserPassword.Size = new System.Drawing.Size(100, 20);
            this.fUserPassword.TabIndex = 11;
            // 
            // fUserName
            // 
            this.fUserName.Location = new System.Drawing.Point(137, 43);
            this.fUserName.Name = "fUserName";
            this.fUserName.Size = new System.Drawing.Size(100, 20);
            this.fUserName.TabIndex = 10;
            // 
            // fServerName
            // 
            this.fServerName.Location = new System.Drawing.Point(17, 43);
            this.fServerName.Name = "fServerName";
            this.fServerName.Size = new System.Drawing.Size(100, 20);
            this.fServerName.TabIndex = 9;
            // 
            // fPanelCompare
            // 
            this.fPanelCompare.Controls.Add(this.fCreateNewList);
            this.fPanelCompare.Controls.Add(this.fCompare);
            this.fPanelCompare.Controls.Add(this.fObject2);
            this.fPanelCompare.Controls.Add(this.fObject1);
            this.fPanelCompare.Enabled = false;
            this.fPanelCompare.Location = new System.Drawing.Point(12, 123);
            this.fPanelCompare.Name = "fPanelCompare";
            this.fPanelCompare.Size = new System.Drawing.Size(451, 148);
            this.fPanelCompare.TabIndex = 20;
            this.fPanelCompare.TabStop = false;
            this.fPanelCompare.Text = "Сравнение";
            // 
            // fCreateNewList
            // 
            this.fCreateNewList.AutoSize = true;
            this.fCreateNewList.Location = new System.Drawing.Point(17, 88);
            this.fCreateNewList.Name = "fCreateNewList";
            this.fCreateNewList.Size = new System.Drawing.Size(298, 17);
            this.fCreateNewList.TabIndex = 22;
            this.fCreateNewList.Text = "Создать новый список для недостающих обновлений";
            this.fCreateNewList.UseVisualStyleBackColor = true;
            // 
            // fCompare
            // 
            this.fCompare.Location = new System.Drawing.Point(17, 111);
            this.fCompare.Name = "fCompare";
            this.fCompare.Size = new System.Drawing.Size(100, 23);
            this.fCompare.TabIndex = 21;
            this.fCompare.Text = "Сравнить";
            this.fCompare.UseVisualStyleBackColor = true;
            this.fCompare.Click += new System.EventHandler(this.fCompare_Click);
            // 
            // fObject2
            // 
            this.fObject2.FormattingEnabled = true;
            this.fObject2.Location = new System.Drawing.Point(17, 61);
            this.fObject2.Name = "fObject2";
            this.fObject2.Size = new System.Drawing.Size(341, 21);
            this.fObject2.TabIndex = 20;
            // 
            // fObject1
            // 
            this.fObject1.FormattingEnabled = true;
            this.fObject1.Location = new System.Drawing.Point(17, 34);
            this.fObject1.Name = "fObject1";
            this.fObject1.Size = new System.Drawing.Size(341, 21);
            this.fObject1.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 306);
            this.Controls.Add(this.fPanelCompare);
            this.Controls.Add(this.fPanelConnect);
            this.Controls.Add(this.fStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCCM 2007 UpdateManager";
            this.fStatus.ResumeLayout(false);
            this.fStatus.PerformLayout();
            this.fPanelConnect.ResumeLayout(false);
            this.fPanelConnect.PerformLayout();
            this.fPanelCompare.ResumeLayout(false);
            this.fPanelCompare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip fStatus;
        private System.Windows.Forms.ToolStripStatusLabel fStatusCopyright;
        private System.Windows.Forms.GroupBox fPanelConnect;
        private System.Windows.Forms.Label fUserPasswordLabel;
        private System.Windows.Forms.Label fUserNameLabel;
        private System.Windows.Forms.Label fServerNameLabel;
        private System.Windows.Forms.Button fConnect;
        private System.Windows.Forms.TextBox fUserPassword;
        private System.Windows.Forms.TextBox fUserName;
        private System.Windows.Forms.TextBox fServerName;
        private System.Windows.Forms.GroupBox fPanelCompare;
        private System.Windows.Forms.CheckBox fCreateNewList;
        private System.Windows.Forms.Button fCompare;
        private System.Windows.Forms.ComboBox fObject2;
        private System.Windows.Forms.ComboBox fObject1;
        private System.Windows.Forms.ToolStripStatusLabel fStatusBlank;

    }
}

