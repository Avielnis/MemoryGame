namespace MemoryGame
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.FirstPlayerLable = new System.Windows.Forms.Label();
            this.SecondPlayerLable = new System.Windows.Forms.Label();
            this.FirstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.AgaisntWho = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.BoradSizeButton = new System.Windows.Forms.Button();
            this.BoarSizeLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstPlayerLable
            // 
            this.FirstPlayerLable.AutoSize = true;
            this.FirstPlayerLable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FirstPlayerLable.Location = new System.Drawing.Point(12, 14);
            this.FirstPlayerLable.Name = "FirstPlayerLable";
            this.FirstPlayerLable.Size = new System.Drawing.Size(92, 13);
            this.FirstPlayerLable.TabIndex = 0;
            this.FirstPlayerLable.Text = "First Player Name:";
            // 
            // SecondPlayerLable
            // 
            this.SecondPlayerLable.AccessibleDescription = "SecondNameLable";
            this.SecondPlayerLable.AccessibleName = "SecondNameLable";
            this.SecondPlayerLable.AutoSize = true;
            this.SecondPlayerLable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SecondPlayerLable.Location = new System.Drawing.Point(12, 43);
            this.SecondPlayerLable.Name = "SecondPlayerLable";
            this.SecondPlayerLable.Size = new System.Drawing.Size(110, 13);
            this.SecondPlayerLable.TabIndex = 1;
            this.SecondPlayerLable.Text = "Second Player Name:";
            // 
            // FirstPlayerNameTextBox
            // 
            this.FirstPlayerNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FirstPlayerNameTextBox.Location = new System.Drawing.Point(145, 11);
            this.FirstPlayerNameTextBox.Name = "FirstPlayerNameTextBox";
            this.FirstPlayerNameTextBox.Size = new System.Drawing.Size(162, 20);
            this.FirstPlayerNameTextBox.TabIndex = 0;
            // 
            // SecondPlayerNameTextBox
            // 
            this.SecondPlayerNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SecondPlayerNameTextBox.Enabled = false;
            this.SecondPlayerNameTextBox.Location = new System.Drawing.Point(145, 43);
            this.SecondPlayerNameTextBox.Name = "SecondPlayerNameTextBox";
            this.SecondPlayerNameTextBox.Size = new System.Drawing.Size(161, 20);
            this.SecondPlayerNameTextBox.TabIndex = 1;
            this.SecondPlayerNameTextBox.Text = "-Computer-";
            // 
            // AgaisntWho
            // 
            this.AgaisntWho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AgaisntWho.Location = new System.Drawing.Point(328, 47);
            this.AgaisntWho.Name = "AgaisntWho";
            this.AgaisntWho.Size = new System.Drawing.Size(123, 23);
            this.AgaisntWho.TabIndex = 3;
            this.AgaisntWho.Text = "Against a Friend";
            this.AgaisntWho.UseVisualStyleBackColor = true;
            this.AgaisntWho.Click += new System.EventHandler(this.AgaisntAFriend_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Lime;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Location = new System.Drawing.Point(352, 127);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // BoradSizeButton
            // 
            this.BoradSizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BoradSizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoradSizeButton.Location = new System.Drawing.Point(15, 85);
            this.BoradSizeButton.Name = "BoradSizeButton";
            this.BoradSizeButton.Size = new System.Drawing.Size(132, 71);
            this.BoradSizeButton.TabIndex = 2;
            this.BoradSizeButton.Text = "4X4";
            this.BoradSizeButton.UseVisualStyleBackColor = false;
            this.BoradSizeButton.Click += new System.EventHandler(this.BoradSizeButton_Click);
            // 
            // BoarSizeLable
            // 
            this.BoarSizeLable.AutoSize = true;
            this.BoarSizeLable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BoarSizeLable.Location = new System.Drawing.Point(12, 65);
            this.BoarSizeLable.Name = "BoarSizeLable";
            this.BoarSizeLable.Size = new System.Drawing.Size(61, 13);
            this.BoarSizeLable.TabIndex = 7;
            this.BoarSizeLable.Text = "Board Size:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 168);
            this.Controls.Add(this.BoarSizeLable);
            this.Controls.Add(this.BoradSizeButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.AgaisntWho);
            this.Controls.Add(this.SecondPlayerNameTextBox);
            this.Controls.Add(this.FirstPlayerNameTextBox);
            this.Controls.Add(this.SecondPlayerLable);
            this.Controls.Add(this.FirstPlayerLable);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstPlayerLable;
        private System.Windows.Forms.Label SecondPlayerLable;
        private System.Windows.Forms.TextBox FirstPlayerNameTextBox;
        private System.Windows.Forms.TextBox SecondPlayerNameTextBox;
        private System.Windows.Forms.Button AgaisntWho;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button BoradSizeButton;
        private System.Windows.Forms.Label BoarSizeLable;
    }
}