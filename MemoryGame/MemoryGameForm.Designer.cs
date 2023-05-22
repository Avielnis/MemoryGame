namespace MemoryGame
{
    partial class MemoryGameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryGameForm));
            this.FirstCard = new System.Windows.Forms.Button();
            this.User1ScoreLable = new System.Windows.Forms.Label();
            this.User2ScoreLable = new System.Windows.Forms.Label();
            this.CurrentPlyaerLable = new System.Windows.Forms.Label();
            this.WaitTimer = new System.Windows.Forms.Timer(this.components);
            this.CompTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FirstCard
            // 
            this.FirstCard.AutoSize = true;
            this.FirstCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FirstCard.Location = new System.Drawing.Point(22, 25);
            this.FirstCard.Name = "FirstCard";
            this.FirstCard.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.FirstCard.Size = new System.Drawing.Size(72, 64);
            this.FirstCard.TabIndex = 0;
            this.FirstCard.UseVisualStyleBackColor = true;
            this.FirstCard.Click += new System.EventHandler(this.FirstCard_Click);
            // 
            // User1ScoreLable
            // 
            this.User1ScoreLable.AutoSize = true;
            this.User1ScoreLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.User1ScoreLable.Location = new System.Drawing.Point(19, 255);
            this.User1ScoreLable.Name = "User1ScoreLable";
            this.User1ScoreLable.Size = new System.Drawing.Size(35, 13);
            this.User1ScoreLable.TabIndex = 1;
            this.User1ScoreLable.Text = "label1";
            // 
            // User2ScoreLable
            // 
            this.User2ScoreLable.AutoSize = true;
            this.User2ScoreLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.User2ScoreLable.Location = new System.Drawing.Point(19, 273);
            this.User2ScoreLable.Name = "User2ScoreLable";
            this.User2ScoreLable.Size = new System.Drawing.Size(35, 13);
            this.User2ScoreLable.TabIndex = 2;
            this.User2ScoreLable.Text = "label1";
            // 
            // CurrentPlyaerLable
            // 
            this.CurrentPlyaerLable.AutoSize = true;
            this.CurrentPlyaerLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CurrentPlyaerLable.Location = new System.Drawing.Point(19, 242);
            this.CurrentPlyaerLable.Name = "CurrentPlyaerLable";
            this.CurrentPlyaerLable.Size = new System.Drawing.Size(35, 13);
            this.CurrentPlyaerLable.TabIndex = 3;
            this.CurrentPlyaerLable.Text = "label1";
            // 
            // WaitTimer
            // 
            this.WaitTimer.Interval = 2000;
            this.WaitTimer.Tick += new System.EventHandler(this.WaitTimer_Tick);
            // 
            // CompTimer
            // 
            this.CompTimer.Interval = 2000;
            this.CompTimer.Tick += new System.EventHandler(this.CompTimer_TickComp);
            // 
            // MemoryGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(406, 296);
            this.Controls.Add(this.CurrentPlyaerLable);
            this.Controls.Add(this.User2ScoreLable);
            this.Controls.Add(this.User1ScoreLable);
            this.Controls.Add(this.FirstCard);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemoryGameForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemoryGameForm_FormClosing);
            this.Load += new System.EventHandler(this.MemoryGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FirstCard;
        private System.Windows.Forms.Label User1ScoreLable;
        private System.Windows.Forms.Label User2ScoreLable;
        private System.Windows.Forms.Label CurrentPlyaerLable;
        private System.Windows.Forms.Timer WaitTimer;
        private System.Windows.Forms.Timer CompTimer;
    }
}