namespace Archiver
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.DelFilesBtn = new System.Windows.Forms.Button();
            this.AddArchiveBtn = new System.Windows.Forms.Button();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.HorizontalScrollbar = true;
            this.listBoxFiles.ItemHeight = 16;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 15);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Size = new System.Drawing.Size(346, 228);
            this.listBoxFiles.TabIndex = 1;
            // 
            // ExitBtn
            // 
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Image = global::Archiver.Properties.Resources.exit3;
            this.ExitBtn.Location = new System.Drawing.Point(12, 257);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(56, 56);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // DelFilesBtn
            // 
            this.DelFilesBtn.FlatAppearance.BorderSize = 0;
            this.DelFilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelFilesBtn.Image = global::Archiver.Properties.Resources.delFile2;
            this.DelFilesBtn.Location = new System.Drawing.Point(153, 257);
            this.DelFilesBtn.Name = "DelFilesBtn";
            this.DelFilesBtn.Size = new System.Drawing.Size(56, 56);
            this.DelFilesBtn.TabIndex = 4;
            this.DelFilesBtn.UseVisualStyleBackColor = true;
            this.DelFilesBtn.Click += new System.EventHandler(this.DelFilesBtn_Click);
            // 
            // AddArchiveBtn
            // 
            this.AddArchiveBtn.FlatAppearance.BorderSize = 0;
            this.AddArchiveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddArchiveBtn.Image = global::Archiver.Properties.Resources.AddArh;
            this.AddArchiveBtn.Location = new System.Drawing.Point(200, 257);
            this.AddArchiveBtn.Name = "AddArchiveBtn";
            this.AddArchiveBtn.Size = new System.Drawing.Size(56, 56);
            this.AddArchiveBtn.TabIndex = 3;
            this.AddArchiveBtn.UseVisualStyleBackColor = true;
            this.AddArchiveBtn.Click += new System.EventHandler(this.AddArchiveBtn_Click);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.FlatAppearance.BorderSize = 0;
            this.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyBtn.Image = global::Archiver.Properties.Resources.galach1;
            this.ApplyBtn.Location = new System.Drawing.Point(302, 257);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(56, 56);
            this.ApplyBtn.TabIndex = 2;
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button1.Image = global::Archiver.Properties.Resources.AddFile;
            this.button1.Location = new System.Drawing.Point(250, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 56);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddFilesBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 315);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.DelFilesBtn);
            this.Controls.Add(this.AddArchiveBtn);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button AddArchiveBtn;
        private System.Windows.Forms.Button DelFilesBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

