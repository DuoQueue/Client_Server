namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.writeMessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.friendListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.ipAdressTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.messageRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.messageRichTextBox.Location = new System.Drawing.Point(12, 80);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.Size = new System.Drawing.Size(464, 373);
            this.messageRichTextBox.TabIndex = 0;
            this.messageRichTextBox.Text = "";
            // 
            // writeMessageRichTextBox
            // 
            this.writeMessageRichTextBox.Location = new System.Drawing.Point(12, 459);
            this.writeMessageRichTextBox.Name = "writeMessageRichTextBox";
            this.writeMessageRichTextBox.Size = new System.Drawing.Size(464, 51);
            this.writeMessageRichTextBox.TabIndex = 1;
            this.writeMessageRichTextBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(482, 459);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(135, 51);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Senden";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // friendListBox
            // 
            this.friendListBox.FormattingEnabled = true;
            this.friendListBox.Location = new System.Drawing.Point(482, 163);
            this.friendListBox.Name = "friendListBox";
            this.friendListBox.Size = new System.Drawing.Size(135, 290);
            this.friendListBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(482, 106);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(135, 20);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.Text = "Namen bitte hinzufügen";
            this.nameTextBox.Click += new System.EventHandler(this.nameTextBox_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(482, 132);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(135, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // ipAdressTextBox
            // 
            this.ipAdressTextBox.Location = new System.Drawing.Point(482, 80);
            this.ipAdressTextBox.Name = "ipAdressTextBox";
            this.ipAdressTextBox.Size = new System.Drawing.Size(135, 20);
            this.ipAdressTextBox.TabIndex = 6;
            this.ipAdressTextBox.Text = "IPAdresse bitte hinzufügen";
            this.ipAdressTextBox.Click += new System.EventHandler(this.ipAdressTextBox_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 522);
            this.Controls.Add(this.ipAdressTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.friendListBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.writeMessageRichTextBox);
            this.Controls.Add(this.messageRichTextBox);
            this.Name = "Client";
            this.Text = "WAT APP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.RichTextBox writeMessageRichTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox friendListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox ipAdressTextBox;


    }
}

