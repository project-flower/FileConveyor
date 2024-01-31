namespace FileConveyor
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTargetDirectory = new System.Windows.Forms.Label();
            this.comboBoxTargetDirectory = new System.Windows.Forms.ComboBox();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.labelFilter = new System.Windows.Forms.Label();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.labelRename = new System.Windows.Forms.Label();
            this.textBoxRename = new System.Windows.Forms.TextBox();
            this.groupBoxDateTime = new System.Windows.Forms.GroupBox();
            this.radioButtonSystem = new System.Windows.Forms.RadioButton();
            this.radioButtonFileCreated = new System.Windows.Forms.RadioButton();
            this.radioButtonFileUpdated = new System.Windows.Forms.RadioButton();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.buttonMoveNow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.groupBoxDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTargetDirectory
            // 
            this.labelTargetDirectory.AutoSize = true;
            this.labelTargetDirectory.Location = new System.Drawing.Point(12, 9);
            this.labelTargetDirectory.Name = "labelTargetDirectory";
            this.labelTargetDirectory.Size = new System.Drawing.Size(91, 12);
            this.labelTargetDirectory.TabIndex = 0;
            this.labelTargetDirectory.Text = "&Target Directory:";
            // 
            // comboBoxTargetDirectory
            // 
            this.comboBoxTargetDirectory.AllowDrop = true;
            this.comboBoxTargetDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTargetDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTargetDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.comboBoxTargetDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileConveyor.Properties.Settings.Default, "TargetDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxTargetDirectory.FormattingEnabled = true;
            this.comboBoxTargetDirectory.Location = new System.Drawing.Point(12, 24);
            this.comboBoxTargetDirectory.Name = "comboBoxTargetDirectory";
            this.comboBoxTargetDirectory.Size = new System.Drawing.Size(776, 20);
            this.comboBoxTargetDirectory.TabIndex = 1;
            this.comboBoxTargetDirectory.Text = global::FileConveyor.Properties.Settings.Default.TargetDirectory;
            this.comboBoxTargetDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBoxDirectory_DragDrop);
            this.comboBoxTargetDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBoxDirectory_DragEnter);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(12, 47);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(34, 12);
            this.labelFilter.TabIndex = 2;
            this.labelFilter.Text = "&Filter:";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileConveyor.Properties.Settings.Default, "Filter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFilter.Location = new System.Drawing.Point(12, 62);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(776, 19);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.Text = global::FileConveyor.Properties.Settings.Default.Filter;
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(12, 84);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(65, 12);
            this.labelDestination.TabIndex = 4;
            this.labelDestination.Text = "&Destination:";
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.AllowDrop = true;
            this.comboBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.comboBoxDestination.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileConveyor.Properties.Settings.Default, "Destination", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Location = new System.Drawing.Point(12, 99);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(776, 20);
            this.comboBoxDestination.TabIndex = 5;
            this.comboBoxDestination.Text = global::FileConveyor.Properties.Settings.Default.Destination;
            this.comboBoxDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBoxDirectory_DragDrop);
            this.comboBoxDestination.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBoxDirectory_DragEnter);
            // 
            // labelRename
            // 
            this.labelRename.AutoSize = true;
            this.labelRename.Location = new System.Drawing.Point(12, 122);
            this.labelRename.Name = "labelRename";
            this.labelRename.Size = new System.Drawing.Size(48, 12);
            this.labelRename.TabIndex = 6;
            this.labelRename.Text = "Rename:";
            // 
            // textBoxRename
            // 
            this.textBoxRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRename.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FileConveyor.Properties.Settings.Default, "Rename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRename.Location = new System.Drawing.Point(12, 137);
            this.textBoxRename.Name = "textBoxRename";
            this.textBoxRename.Size = new System.Drawing.Size(776, 19);
            this.textBoxRename.TabIndex = 7;
            this.textBoxRename.Text = global::FileConveyor.Properties.Settings.Default.Rename;
            // 
            // groupBoxDateTime
            // 
            this.groupBoxDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDateTime.Controls.Add(this.radioButtonSystem);
            this.groupBoxDateTime.Controls.Add(this.radioButtonFileCreated);
            this.groupBoxDateTime.Controls.Add(this.radioButtonFileUpdated);
            this.groupBoxDateTime.Location = new System.Drawing.Point(12, 162);
            this.groupBoxDateTime.Name = "groupBoxDateTime";
            this.groupBoxDateTime.Size = new System.Drawing.Size(776, 40);
            this.groupBoxDateTime.TabIndex = 8;
            this.groupBoxDateTime.TabStop = false;
            this.groupBoxDateTime.Text = "DateTime";
            // 
            // radioButtonSystem
            // 
            this.radioButtonSystem.AutoSize = true;
            this.radioButtonSystem.Location = new System.Drawing.Point(192, 18);
            this.radioButtonSystem.Name = "radioButtonSystem";
            this.radioButtonSystem.Size = new System.Drawing.Size(94, 16);
            this.radioButtonSystem.TabIndex = 2;
            this.radioButtonSystem.TabStop = true;
            this.radioButtonSystem.Text = "&System Clock";
            this.radioButtonSystem.UseVisualStyleBackColor = true;
            // 
            // radioButtonFileCreated
            // 
            this.radioButtonFileCreated.AutoSize = true;
            this.radioButtonFileCreated.Location = new System.Drawing.Point(100, 18);
            this.radioButtonFileCreated.Name = "radioButtonFileCreated";
            this.radioButtonFileCreated.Size = new System.Drawing.Size(86, 16);
            this.radioButtonFileCreated.TabIndex = 1;
            this.radioButtonFileCreated.TabStop = true;
            this.radioButtonFileCreated.Text = "File &Created";
            this.radioButtonFileCreated.UseVisualStyleBackColor = true;
            // 
            // radioButtonFileUpdated
            // 
            this.radioButtonFileUpdated.AutoSize = true;
            this.radioButtonFileUpdated.Checked = true;
            this.radioButtonFileUpdated.Location = new System.Drawing.Point(6, 18);
            this.radioButtonFileUpdated.Name = "radioButtonFileUpdated";
            this.radioButtonFileUpdated.Size = new System.Drawing.Size(88, 16);
            this.radioButtonFileUpdated.TabIndex = 0;
            this.radioButtonFileUpdated.TabStop = true;
            this.radioButtonFileUpdated.Text = "File &Updated";
            this.radioButtonFileUpdated.UseVisualStyleBackColor = true;
            // 
            // buttonEnable
            // 
            this.buttonEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnable.Location = new System.Drawing.Point(551, 208);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(75, 23);
            this.buttonEnable.TabIndex = 9;
            this.buttonEnable.Text = "&Enable";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // buttonDisable
            // 
            this.buttonDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisable.Enabled = false;
            this.buttonDisable.Location = new System.Drawing.Point(632, 208);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(75, 23);
            this.buttonDisable.TabIndex = 10;
            this.buttonDisable.Text = "&Disable";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
            // 
            // buttonMoveNow
            // 
            this.buttonMoveNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveNow.Location = new System.Drawing.Point(713, 208);
            this.buttonMoveNow.Name = "buttonMoveNow";
            this.buttonMoveNow.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveNow.TabIndex = 11;
            this.buttonMoveNow.Text = "Move &Now";
            this.buttonMoveNow.UseVisualStyleBackColor = true;
            this.buttonMoveNow.Click += new System.EventHandler(this.buttonMoveNow_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 243);
            this.Controls.Add(this.buttonMoveNow);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.buttonEnable);
            this.Controls.Add(this.groupBoxDateTime);
            this.Controls.Add(this.textBoxRename);
            this.Controls.Add(this.labelRename);
            this.Controls.Add(this.comboBoxDestination);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.comboBoxTargetDirectory);
            this.Controls.Add(this.labelTargetDirectory);
            this.Name = "FormMain";
            this.Text = "FileConveyor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.Shown += new System.EventHandler(this.shown);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.groupBoxDateTime.ResumeLayout(false);
            this.groupBoxDateTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTargetDirectory;
        private System.Windows.Forms.ComboBox comboBoxTargetDirectory;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.ComboBox comboBoxDestination;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.TextBox textBoxRename;
        private System.Windows.Forms.Label labelRename;
        private System.Windows.Forms.GroupBox groupBoxDateTime;
        private System.Windows.Forms.RadioButton radioButtonSystem;
        private System.Windows.Forms.RadioButton radioButtonFileCreated;
        private System.Windows.Forms.RadioButton radioButtonFileUpdated;
        private System.Windows.Forms.Button buttonMoveNow;
        private System.Windows.Forms.Button buttonDisable;
        private System.Windows.Forms.Button buttonEnable;
    }
}

