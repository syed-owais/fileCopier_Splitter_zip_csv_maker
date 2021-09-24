namespace FileCopier
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCopy = new System.Windows.Forms.Button();
            this.btndesdir = new System.Windows.Forms.Button();
            this.btnsrc = new System.Windows.Forms.Button();
            this.txtsrc = new System.Windows.Forms.TextBox();
            this.txtdir = new System.Windows.Forms.TextBox();
            this.lblsrc = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bntCopyFileInlist = new System.Windows.Forms.Button();
            this.txtPindex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkboxAppendName = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateParent = new System.Windows.Forms.CheckBox();
            this.checkBoxGetSubdirs = new System.Windows.Forms.CheckBox();
            this.btnCreateZip = new System.Windows.Forms.Button();
            this.txtSplitQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCSV = new System.Windows.Forms.Button();
            this.chkIsfile = new System.Windows.Forms.CheckBox();
            this.checkBoxwithoutDisplay = new System.Windows.Forms.CheckBox();
            this.txtSearchtext = new System.Windows.Forms.TextBox();
            this.btnSearchText = new System.Windows.Forms.Button();
            this.txtFileLimit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblfilesFound = new System.Windows.Forms.Label();
            this.lblTotalproccessed = new System.Windows.Forms.Label();
            this.chkRmoveSameFile = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewProcess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 479);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(180, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy Files with timmer";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btndesdir
            // 
            this.btndesdir.Location = new System.Drawing.Point(11, 298);
            this.btndesdir.Name = "btndesdir";
            this.btndesdir.Size = new System.Drawing.Size(129, 23);
            this.btndesdir.TabIndex = 4;
            this.btndesdir.Text = "Target Directory";
            this.btndesdir.UseVisualStyleBackColor = true;
            this.btndesdir.Click += new System.EventHandler(this.btndesdir_Click);
            // 
            // btnsrc
            // 
            this.btnsrc.Location = new System.Drawing.Point(12, 39);
            this.btnsrc.Name = "btnsrc";
            this.btnsrc.Size = new System.Drawing.Size(129, 23);
            this.btnsrc.TabIndex = 5;
            this.btnsrc.Text = "Source Directory";
            this.btnsrc.UseVisualStyleBackColor = true;
            this.btnsrc.Click += new System.EventHandler(this.btnsrc_Click);
            // 
            // txtsrc
            // 
            this.txtsrc.Location = new System.Drawing.Point(160, 42);
            this.txtsrc.Name = "txtsrc";
            this.txtsrc.Size = new System.Drawing.Size(241, 20);
            this.txtsrc.TabIndex = 7;
            this.txtsrc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsrc_KeyPress);
            // 
            // txtdir
            // 
            this.txtdir.Location = new System.Drawing.Point(159, 300);
            this.txtdir.Name = "txtdir";
            this.txtdir.Size = new System.Drawing.Size(241, 20);
            this.txtdir.TabIndex = 8;
            // 
            // lblsrc
            // 
            this.lblsrc.AutoSize = true;
            this.lblsrc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsrc.Location = new System.Drawing.Point(420, 15);
            this.lblsrc.Name = "lblsrc";
            this.lblsrc.Size = new System.Drawing.Size(0, 19);
            this.lblsrc.TabIndex = 2;
            // 
            // txtstatus
            // 
            this.txtstatus.Location = new System.Drawing.Point(11, 324);
            this.txtstatus.Multiline = true;
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.ReadOnly = true;
            this.txtstatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtstatus.Size = new System.Drawing.Size(389, 43);
            this.txtstatus.TabIndex = 9;
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(12, 196);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(389, 79);
            this.checkedListBox.TabIndex = 10;
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(301, 121);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(100, 20);
            this.txtPattern.TabIndex = 12;
            this.txtPattern.Tag = "";
            this.txtPattern.Enter += new System.EventHandler(this.RemoveText);
            this.txtPattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPattern_KeyPress);
            this.txtPattern.Leave += new System.EventHandler(this.AddText);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "File Search Pattren:";
            // 
            // bntCopyFileInlist
            // 
            this.bntCopyFileInlist.Location = new System.Drawing.Point(198, 479);
            this.bntCopyFileInlist.Name = "bntCopyFileInlist";
            this.bntCopyFileInlist.Size = new System.Drawing.Size(203, 23);
            this.bntCopyFileInlist.TabIndex = 14;
            this.bntCopyFileInlist.Text = "Copy Files in list";
            this.bntCopyFileInlist.UseVisualStyleBackColor = true;
            this.bntCopyFileInlist.Click += new System.EventHandler(this.bntCopyFileInlist_Click);
            // 
            // txtPindex
            // 
            this.txtPindex.Location = new System.Drawing.Point(100, 97);
            this.txtPindex.Name = "txtPindex";
            this.txtPindex.Size = new System.Drawing.Size(41, 20);
            this.txtPindex.TabIndex = 15;
            this.txtPindex.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Parent Dir index:";
            // 
            // checkboxAppendName
            // 
            this.checkboxAppendName.AutoSize = true;
            this.checkboxAppendName.Location = new System.Drawing.Point(11, 147);
            this.checkboxAppendName.Name = "checkboxAppendName";
            this.checkboxAppendName.Size = new System.Drawing.Size(150, 17);
            this.checkboxAppendName.TabIndex = 17;
            this.checkboxAppendName.Text = "Append Parent DIR Name";
            this.checkboxAppendName.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreateParent
            // 
            this.checkBoxCreateParent.AutoSize = true;
            this.checkBoxCreateParent.Location = new System.Drawing.Point(164, 147);
            this.checkBoxCreateParent.Name = "checkBoxCreateParent";
            this.checkBoxCreateParent.Size = new System.Drawing.Size(113, 17);
            this.checkBoxCreateParent.TabIndex = 18;
            this.checkBoxCreateParent.Text = "Create Parent DIR";
            this.checkBoxCreateParent.UseVisualStyleBackColor = true;
            // 
            // checkBoxGetSubdirs
            // 
            this.checkBoxGetSubdirs.AutoSize = true;
            this.checkBoxGetSubdirs.Location = new System.Drawing.Point(283, 147);
            this.checkBoxGetSubdirs.Name = "checkBoxGetSubdirs";
            this.checkBoxGetSubdirs.Size = new System.Drawing.Size(81, 17);
            this.checkBoxGetSubdirs.TabIndex = 19;
            this.checkBoxGetSubdirs.Text = "Get Subdirs";
            this.checkBoxGetSubdirs.UseVisualStyleBackColor = true;
            // 
            // btnCreateZip
            // 
            this.btnCreateZip.Location = new System.Drawing.Point(280, 508);
            this.btnCreateZip.Name = "btnCreateZip";
            this.btnCreateZip.Size = new System.Drawing.Size(121, 23);
            this.btnCreateZip.TabIndex = 20;
            this.btnCreateZip.Text = "Create ZIP";
            this.btnCreateZip.UseVisualStyleBackColor = true;
            this.btnCreateZip.Click += new System.EventHandler(this.btnCreateZip_Click);
            // 
            // txtSplitQty
            // 
            this.txtSplitQty.Location = new System.Drawing.Point(150, 508);
            this.txtSplitQty.Name = "txtSplitQty";
            this.txtSplitQty.Size = new System.Drawing.Size(110, 20);
            this.txtSplitQty.TabIndex = 21;
            this.txtSplitQty.Text = "1";
            this.txtSplitQty.TextChanged += new System.EventHandler(this.txtSplitQty_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 511);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Split Qty / ZIP | Qty / CSV:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(12, 170);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            this.checkBoxSelectAll.TabIndex = 23;
            this.checkBoxSelectAll.Text = "Select All";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Clear List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 197);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(167, 168);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(107, 20);
            this.txtFilter.TabIndex = 26;
            this.txtFilter.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Filter Dir not inc";
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(12, 534);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(389, 23);
            this.btnCSV.TabIndex = 28;
            this.btnCSV.Text = "Create CSV for Dspace";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // chkIsfile
            // 
            this.chkIsfile.AutoSize = true;
            this.chkIsfile.Location = new System.Drawing.Point(297, 99);
            this.chkIsfile.Name = "chkIsfile";
            this.chkIsfile.Size = new System.Drawing.Size(104, 17);
            this.chkIsfile.TabIndex = 29;
            this.chkIsfile.Text = "Apply Filer in File";
            this.chkIsfile.UseVisualStyleBackColor = true;
            // 
            // checkBoxwithoutDisplay
            // 
            this.checkBoxwithoutDisplay.AutoSize = true;
            this.checkBoxwithoutDisplay.Location = new System.Drawing.Point(11, 123);
            this.checkBoxwithoutDisplay.Name = "checkBoxwithoutDisplay";
            this.checkBoxwithoutDisplay.Size = new System.Drawing.Size(189, 17);
            this.checkBoxwithoutDisplay.TabIndex = 31;
            this.checkBoxwithoutDisplay.Text = "Run Entire Process without display";
            this.checkBoxwithoutDisplay.UseVisualStyleBackColor = true;
            // 
            // txtSearchtext
            // 
            this.txtSearchtext.Location = new System.Drawing.Point(54, 67);
            this.txtSearchtext.Name = "txtSearchtext";
            this.txtSearchtext.Size = new System.Drawing.Size(146, 20);
            this.txtSearchtext.TabIndex = 32;
            // 
            // btnSearchText
            // 
            this.btnSearchText.Location = new System.Drawing.Point(297, 66);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(104, 23);
            this.btnSearchText.TabIndex = 33;
            this.btnSearchText.Text = "Search Text in Src Dir";
            this.btnSearchText.UseVisualStyleBackColor = true;
            this.btnSearchText.Click += new System.EventHandler(this.btnSearchText_Click);
            // 
            // txtFileLimit
            // 
            this.txtFileLimit.Location = new System.Drawing.Point(219, 67);
            this.txtFileLimit.Name = "txtFileLimit";
            this.txtFileLimit.Size = new System.Drawing.Size(41, 20);
            this.txtFileLimit.TabIndex = 34;
            this.txtFileLimit.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Search:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Files";
            // 
            // lblfilesFound
            // 
            this.lblfilesFound.AutoSize = true;
            this.lblfilesFound.Location = new System.Drawing.Point(12, 282);
            this.lblfilesFound.Name = "lblfilesFound";
            this.lblfilesFound.Size = new System.Drawing.Size(61, 13);
            this.lblfilesFound.TabIndex = 38;
            this.lblfilesFound.Text = "Found files:";
            // 
            // lblTotalproccessed
            // 
            this.lblTotalproccessed.AutoSize = true;
            this.lblTotalproccessed.Location = new System.Drawing.Point(203, 282);
            this.lblTotalproccessed.Name = "lblTotalproccessed";
            this.lblTotalproccessed.Size = new System.Drawing.Size(115, 13);
            this.lblTotalproccessed.TabIndex = 39;
            this.lblTotalproccessed.Text = "In total processed files:";
            // 
            // chkRmoveSameFile
            // 
            this.chkRmoveSameFile.AutoSize = true;
            this.chkRmoveSameFile.Location = new System.Drawing.Point(208, 457);
            this.chkRmoveSameFile.Name = "chkRmoveSameFile";
            this.chkRmoveSameFile.Size = new System.Drawing.Size(182, 17);
            this.chkRmoveSameFile.TabIndex = 40;
            this.chkRmoveSameFile.Text = "Remove same  file from targer Dir";
            this.chkRmoveSameFile.UseVisualStyleBackColor = true;
            this.chkRmoveSameFile.CheckedChanged += new System.EventHandler(this.chkRmoveSameFile_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(0, 200);
            this.panel1.Location = new System.Drawing.Point(10, 373);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(390, 78);
            this.panel1.TabIndex = 41;
            // 
            // btnNewProcess
            // 
            this.btnNewProcess.Enabled = false;
            this.btnNewProcess.Location = new System.Drawing.Point(12, 10);
            this.btnNewProcess.Name = "btnNewProcess";
            this.btnNewProcess.Size = new System.Drawing.Size(388, 23);
            this.btnNewProcess.TabIndex = 42;
            this.btnNewProcess.Text = "Create New Process";
            this.btnNewProcess.UseVisualStyleBackColor = true;
            this.btnNewProcess.Click += new System.EventHandler(this.btnNewProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 569);
            this.Controls.Add(this.btnNewProcess);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkRmoveSameFile);
            this.Controls.Add(this.lblTotalproccessed);
            this.Controls.Add(this.lblfilesFound);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFileLimit);
            this.Controls.Add(this.btnSearchText);
            this.Controls.Add(this.txtSearchtext);
            this.Controls.Add(this.checkBoxwithoutDisplay);
            this.Controls.Add(this.chkIsfile);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSplitQty);
            this.Controls.Add(this.btnCreateZip);
            this.Controls.Add(this.checkBoxGetSubdirs);
            this.Controls.Add(this.checkBoxCreateParent);
            this.Controls.Add(this.checkboxAppendName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPindex);
            this.Controls.Add(this.bntCopyFileInlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.txtdir);
            this.Controls.Add(this.txtsrc);
            this.Controls.Add(this.btnsrc);
            this.Controls.Add(this.btndesdir);
            this.Controls.Add(this.lblsrc);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "File Copier";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btndesdir;
        private System.Windows.Forms.Button btnsrc;
        private System.Windows.Forms.TextBox txtsrc;
        private System.Windows.Forms.TextBox txtdir;
        private System.Windows.Forms.Label lblsrc;
        private System.Windows.Forms.TextBox txtstatus;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntCopyFileInlist;
        private System.Windows.Forms.TextBox txtPindex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkboxAppendName;
        private System.Windows.Forms.CheckBox checkBoxCreateParent;
        private System.Windows.Forms.CheckBox checkBoxGetSubdirs;
        private System.Windows.Forms.Button btnCreateZip;
        private System.Windows.Forms.TextBox txtSplitQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.CheckBox chkIsfile;
        private System.Windows.Forms.CheckBox checkBoxwithoutDisplay;
        private System.Windows.Forms.TextBox txtSearchtext;
        private System.Windows.Forms.Button btnSearchText;
        private System.Windows.Forms.TextBox txtFileLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblfilesFound;
        private System.Windows.Forms.Label lblTotalproccessed;
        private System.Windows.Forms.CheckBox chkRmoveSameFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewProcess;
    }
}

