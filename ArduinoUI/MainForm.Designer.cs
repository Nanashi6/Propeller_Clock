namespace ArduinoUI
{
    partial class MainForm
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
            this.ArduinoButton = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.AnalogClockButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ArduinoButton
            // 
            this.ArduinoButton.Location = new System.Drawing.Point(12, 12);
            this.ArduinoButton.Name = "ArduinoButton";
            this.ArduinoButton.Size = new System.Drawing.Size(121, 23);
            this.ArduinoButton.TabIndex = 0;
            this.ArduinoButton.Text = "Найти COM-порт";
            this.ArduinoButton.UseVisualStyleBackColor = true;
            this.ArduinoButton.Click += new System.EventHandler(this.ArduinoButton_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(12, 41);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 4;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 68);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(121, 23);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Подключится";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текст для отображения";
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(146, 126);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(124, 20);
            this.MessageText.TabIndex = 7;
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Location = new System.Drawing.Point(101, 152);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(75, 23);
            this.SendMessageButton.TabIndex = 8;
            this.SendMessageButton.Text = "Отправить";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(101, 181);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Сбросить";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // AnalogClockButton
            // 
            this.AnalogClockButton.Location = new System.Drawing.Point(77, 97);
            this.AnalogClockButton.Name = "AnalogClockButton";
            this.AnalogClockButton.Size = new System.Drawing.Size(124, 23);
            this.AnalogClockButton.TabIndex = 10;
            this.AnalogClockButton.Text = "Режим Ан. часов";
            this.AnalogClockButton.UseVisualStyleBackColor = true;
            this.AnalogClockButton.Click += new System.EventHandler(this.AnalogClockButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 215);
            this.Controls.Add(this.AnalogClockButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.ArduinoButton);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ArduinoButton;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button AnalogClockButton;
    }
}

