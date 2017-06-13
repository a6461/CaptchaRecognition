namespace CaptchaRecognition
{
    partial class CaptchaForm
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
            this.captchaBox = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.LoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.Recognize = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.captchaBox)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // captchaBox
            // 
            this.captchaBox.BackColor = System.Drawing.SystemColors.Window;
            this.captchaBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.captchaBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.captchaBox.Location = new System.Drawing.Point(0, 24);
            this.captchaBox.Name = "captchaBox";
            this.captchaBox.Size = new System.Drawing.Size(321, 84);
            this.captchaBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.captchaBox.TabIndex = 0;
            this.captchaBox.TabStop = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(321, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // LoadMenuItem
            // 
            this.LoadMenuItem.Name = "LoadMenuItem";
            this.LoadMenuItem.Size = new System.Drawing.Size(143, 20);
            this.LoadMenuItem.Text = "Выбрать изображение";
            this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // Recognize
            // 
            this.Recognize.Location = new System.Drawing.Point(234, 152);
            this.Recognize.Name = "Recognize";
            this.Recognize.Size = new System.Drawing.Size(75, 23);
            this.Recognize.TabIndex = 3;
            this.Recognize.Text = "Распознать";
            this.Recognize.UseVisualStyleBackColor = true;
            this.Recognize.Click += new System.EventHandler(this.Recognize_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(12, 157);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(62, 13);
            this.result.TabIndex = 4;
            this.result.Text = "Результат:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 124);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(206, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Морфологические преобразования";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CaptchaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 190);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.Recognize);
            this.Controls.Add(this.captchaBox);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "CaptchaForm";
            this.Text = "Распознавание капчи";
            ((System.ComponentModel.ISupportInitialize)(this.captchaBox)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox captchaBox;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem LoadMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button Recognize;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

