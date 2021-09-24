using Microsoft.TeamFoundation.WorkItemTracking.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FileCopier
{
    public partial class Form1 : Form
    {
        static string stxtstatus = "";
        public static string srcPath = null, dirPath = null, status;
        int gCount = 0;
        public Form1()
        {
            InitializeComponent();

            txtPattern.Text = "i.e (*.pdf)";
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (txtPattern.Text == "i.e (*.pdf)")
            {
                txtPattern.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPattern.Text))
                txtPattern.Text = "i.e (*.pdf)";
        }
        private static System.Timers.Timer aTimer;
        
        // Specify what you want to happen when the Elapsed event is  
        // raised. 
       


        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Normally, the timer is declared at the class level, 
            // so that it stays in scope as long as it is needed. 
            // If the timer is declared in a long-running method,   
            // KeepAlive must be used to prevent the JIT compiler  
            // from allowing aggressive garbage collection to occur  
            // before the method ends. You can experiment with this 
            // by commenting out the class-level declaration and  
            // uncommenting the declaration below; then uncomment 
            // the GC.KeepAlive(aTimer) at the end of the method. 
            //System.Timers.Timer aTimer; 

            // Create a timer with a ten second interval.
            aTimer = new System.Timers.Timer(1440000);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // Set the Interval to 2 seconds (2000 milliseconds).
            // Set the Interval to 5 mins (300000 milliseconds).
            aTimer.Interval = 5000;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();

            // If the timer is declared in a long-running method, use 
            // KeepAlive to prevent garbage collection from occurring 
            // before the method ends. 
            GC.KeepAlive(aTimer);
            CopyDirectory(txtsrc.Text, txtdir.Text);
            srcPath = txtsrc.Text;
            dirPath = txtdir.Text;
            //CopyDirectory("D:\\temp\\cam\\new filterd tgsc\\www.thegoodscentscompany.com\\data", "D:\\temp\\cam\\new filterd tgsc\\www.thegoodscentscompany.com\\data_copy");
        }

        private static void CopyDirectory(string srcdir, string desdir)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);
            string desfolderdir = desdir + "\\" + folderName;
            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }

            var filenames = Directory.EnumerateFiles(srcdir, "*", SearchOption.AllDirectories).Where(x => !Path.GetExtension(x).Equals(".dem", StringComparison.OrdinalIgnoreCase));
            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {
                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }
                    CopyDirectory(file, desfolderdir);
                }
                else
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                    srcfileName = desfolderdir + "\\" + srcfileName;
                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }
                    if (!File.Exists(srcfileName))
                    {
                        File.Copy(file, srcfileName);
                    }
                }
            }//foreach
            MessageBox.Show("success");
        }//function end

        private void btnsrc_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    txtsrc.Text = fbd.SelectedPath ;
                    srcPath = txtsrc.Text;
                    lblsrc.Text = "File lenght " + files.Length.ToString();
                    //System.Windows.Forms.MessageBox.Show(result + "Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
        private void txtsrc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtsrc.Text != "")
                {
                    pictureBox1.Visible = true;
                    //var txtFiles = Directory.EnumerateDirectories(txtsrc.Text, (String.IsNullOrEmpty(txtPattern.Text) || txtPattern.Text == "i.e (*.pdf)" ? "*.*" : txtPattern.Text), (checkBoxGetSubdirs.Checked ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories)).AsParallel();
                    int i = 0;
                    
                    foreach (string currentFile in CreateBlockingCollection(chkIsfile.Checked ? true : false ))
                    {
                        string fileName = currentFile.Substring(txtsrc.Text.Length + 1);
                        string path = txtsrc.Text;

                        checkedListBox.DisplayMember = fileName;
                        checkedListBox.ValueMember = txtsrc.Text;
                        checkedListBox.Items.Insert(i, path + "\\" + fileName);
                        checkedListBox.SetItemChecked(i, true);
                        txtstatus.AppendText(Environment.NewLine + i + ": " + path + "\\" + fileName);
                        i++;
                    }
                                        
                    pictureBox1.Visible = false;
                }
            }
        }

        private BlockingCollection<string> CreateBlockingCollection(bool isFile = false, int index = 0, string text = "",int limit = 0)
        {
            var filePaths = new BlockingCollection<string>();
            int count = 0;
            int procCount = 0;
            if (isFile && index > 0)
            {
                var filenames = Directory.EnumerateFiles((string)checkedListBox.Items[index], "*", SearchOption.AllDirectories);
                foreach (var fileName in filenames)
                {
                    filePaths.Add(fileName);
                    procCount++;
                    if (limit > 0 && count >= limit)
                    {
                        break;
                    }
                    count++;
                }
                filePaths.CompleteAdding();
                //lblTotalproccessed.Text = "In total processed files: " + procCount;
                //lblfilesFound.Text = "Found files: " + count;
                gCount = count;
                return filePaths;
            }
            if (isFile && index == 0 && text == "")
            {
                var filenames = Directory.EnumerateFiles(txtsrc.Text, (String.IsNullOrEmpty(txtPattern.Text) || txtPattern.Text == "i.e (*.pdf)" ? "*.*" : txtPattern.Text), SearchOption.AllDirectories);
                foreach (var fileName in filenames)
                {
                    filePaths.Add(fileName);
                    procCount++;
                    if (limit > 0 && count >= limit)
                    {
                        break;
                    }
                    count++;
                }
                filePaths.CompleteAdding();
                //lblTotalproccessed.Text = "In total processed files: " + procCount;
                //lblfilesFound.Text = "Found files: " + count;
                gCount = count;
                return filePaths;
            }
            if (isFile && index == 0 && text != "")
            {
                var filenames = Directory.EnumerateFiles(txtsrc.Text, (String.IsNullOrEmpty(txtPattern.Text) || txtPattern.Text == "i.e (*.pdf)" ? "*.*" : txtPattern.Text), SearchOption.AllDirectories);
                foreach (var fileName in filenames)
                {
                    var Lines = (Path.GetExtension(fileName) == ".html") ? HtmlFilter.ConvertToPlainText(File.ReadAllText(fileName)).Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("   ", " ").Trim().ToLower() : File.ReadAllText(fileName);
                    var Matched = Lines.Contains(text.ToLower());
                    procCount++;
                    if (!Matched)
                    {
                        continue;
                    }
                    filePaths.Add(fileName);
                    if (limit > 0 && count >= limit)
                    {
                        break;
                    }
                    count++;
                }
                filePaths.CompleteAdding();
                //lblTotalproccessed.Text = "In total processed files: " + procCount;
                //lblfilesFound.Text = "Found files: " + count;
                gCount = count;
                return filePaths;
            }
            else
            {
                var txtFiles = Directory.EnumerateDirectories(txtsrc.Text, (String.IsNullOrEmpty(txtPattern.Text) || txtPattern.Text == "i.e (*.pdf)" ? "*.*" : txtPattern.Text), (checkBoxGetSubdirs.Checked ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories));
                foreach (var fileName in txtFiles)
                {
                    filePaths.Add(fileName);
                    procCount++;
                    if (limit > 0 && count >= limit)
                    {
                        break;
                    }
                    count++;
                }
                filePaths.CompleteAdding();
                //lblTotalproccessed.Text = "In total processed files: " + procCount;
                //lblfilesFound.Text = "Found files: " + count;
                gCount = count;
                return filePaths;
            }

        }

        private void txtPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtsrc_KeyPress(sender, e);
            }
        }

        private void bntCopyFileInlist_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtdir.Text))
            {
                return;
            }
            
            bntCopyFileInlist.Enabled = false;
            var worker1 = new BackgroundWorker { WorkerReportsProgress = true };
            DoWorkEventHandler doWork = (snd, ev) =>
            {
                copyFiles();
            };
            worker1.DoWork += doWork;
            //worker1.ProgressChanged += (snd, ev) =>
            //{
            //    pBar.Value = ev.ProgressPercentage;
            //};
            worker1.RunWorkerCompleted += (snd, ev) => { bntCopyFileInlist.Enabled = true; };
            worker1.WorkerReportsProgress = true;
            worker1.WorkerSupportsCancellation = true;
            worker1.RunWorkerAsync();
            //MessageBox.Show("Done.");

        }
        public void copyFiles() {
            Label label = new Label();
            label.Text = "Coping Files to: " + txtdir.Text;
            //label.Text = "Coping Files";
            label.Dock = DockStyle.Top;
            label.Font = new Font("Microsoft Sans Serif", 9);

            ProgressBar pBar = new ProgressBar();
            pBar.Location = new Point(20, 20);
            pBar.Name = "prg_" + txtdir.Text;
            pBar.Width = 200;
            pBar.Height = 20;
            pBar.Dock = DockStyle.Top;
            pBar.Minimum = 0;
            pBar.Maximum = 0;

            panel1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                panel1.Controls.Add(label);
                panel1.Controls.Add(pBar);

            });

            if (checkBoxwithoutDisplay.Checked)
            {
                if (txtsrc.Text != "")
                {
                    string folderName = txtsrc.Text.Substring(txtsrc.Text.LastIndexOf("\\") + 1);
                    string desfolderdir = txtdir.Text + "\\";// + folderName;
                    string AppendDIRname = "";
                    int i = 0;
                    foreach (string file in CreateBlockingCollection(true, 0, txtSearchtext.Text, Convert.ToInt16((String.IsNullOrEmpty(txtFileLimit.Text) || String.IsNullOrWhiteSpace(txtFileLimit.Text)) ? "0" : txtFileLimit.Text)))
                    {
                        i++;
                        string[] dirnames = file.Split(':');
                        dirnames = dirnames[1].Split('\\');
                        if (checkBoxCreateParent.Checked)
                        {
                            if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                            {
                                desfolderdir = txtdir.Text + "\\" + dirnames[Convert.ToInt16(txtPindex.Text)].ToString();
                            }
                        }
                        if (checkboxAppendName.Checked)
                        {
                            if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                            {
                                AppendDIRname = dirnames[Convert.ToInt16(txtPindex.Text)].ToString() + "_";
                            }
                        }
                        if (txtFilter.Text != "")
                        {
                            if (dirnames.Contains(txtFilter.Text))
                            {
                                continue;
                            }
                        }
                        string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                        srcfileName = desfolderdir + "\\" + AppendDIRname + DateTime.Now.ToString("ddMMyyHHmmssms") + i + srcfileName;
                        Directory.CreateDirectory(desfolderdir);

                        if (chkRmoveSameFile.Checked)
                        {
                            if (File.Exists(srcfileName))
                            {
                                File.Delete(srcfileName);
                                txtstatus.AppendText(Environment.NewLine + "Duplication Detected File: " + srcfileName + " Removed.");
                                continue;
                            }
                        }

                        if (!File.Exists(srcfileName))
                        {
                            File.Copy(file, srcfileName);
                        }

                        pBar.Invoke((MethodInvoker)delegate {
                            if (pBar.Maximum < 1)
                            {
                                pBar.Maximum = gCount;
                            }
                            pBar.Value = i;
                        });
                        //pBar.Value = (int)(((double)i / gCount) * 100);

                    }//foreach
                }
            }
            else
            {

                string folderName = txtsrc.Text.Substring(txtsrc.Text.LastIndexOf("\\") + 1);
                string desfolderdir = txtdir.Text + "\\";// + folderName;
                string AppendDIRname = "";
                int k = 0;
                if (chkIsfile.Checked)
                {
                    foreach (string file in checkedListBox.CheckedItems)
                    {
                        string[] dirnames = file.Split(':');
                        dirnames = dirnames[1].Split('\\');
                        if (checkBoxCreateParent.Checked)
                        {
                            if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                            {
                                desfolderdir = txtdir.Text + "\\" + dirnames[Convert.ToInt16(txtPindex.Text)].ToString();
                            }
                        }
                        if (checkboxAppendName.Checked)
                        {
                            if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                            {
                                AppendDIRname = dirnames[Convert.ToInt16(txtPindex.Text)].ToString() + "_";
                            }
                        }
                        if (txtFilter.Text != "")
                        {
                            if (dirnames.Contains(txtFilter.Text))
                            {
                                continue;
                            }
                        }
                        k++;
                        string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                        srcfileName = desfolderdir + "\\" + AppendDIRname + DateTime.Now.ToString("ddMMyyHHmmssms") + k + srcfileName;
                        Directory.CreateDirectory(desfolderdir);
                        if (chkRmoveSameFile.Checked)
                        {
                            if (File.Exists(srcfileName))
                            {
                                File.Delete(srcfileName);
                                txtstatus.AppendText(Environment.NewLine + "Duplication Detected File: " + srcfileName + " Removed.");
                                continue;
                            }
                        }
                        if (!File.Exists(srcfileName))
                        {
                            File.Copy(file, srcfileName);
                        }

                        pBar.Invoke((MethodInvoker)delegate {
                            if (pBar.Maximum < 1)
                            {
                                pBar.Maximum = gCount;
                            }
                            pBar.Value = k;
                        });
                        //pBar.Value = (int)(((double)k / gCount) * 100);

                    }
                }
                else
                {
                    for (int i = 0; i <= checkedListBox.CheckedItems.Count; i++)
                    {
                        foreach (string file in CreateBlockingCollection(true, i, txtSearchtext.Text, Convert.ToInt16((String.IsNullOrEmpty(txtFileLimit.Text) || String.IsNullOrWhiteSpace(txtFileLimit.Text)) ? "0" : txtFileLimit.Text)))
                        {
                            string[] dirnames = file.Split(':');
                            dirnames = dirnames[1].Split('\\');
                            if (checkBoxCreateParent.Checked)
                            {
                                if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                                {
                                    desfolderdir = txtdir.Text + "\\" + dirnames[Convert.ToInt16(txtPindex.Text)].ToString();
                                }
                            }
                            if (checkboxAppendName.Checked)
                            {
                                if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                                {
                                    AppendDIRname = dirnames[Convert.ToInt16(txtPindex.Text)].ToString() + "_";
                                }
                            }
                            if (txtFilter.Text != "")
                            {
                                if (dirnames.Contains(txtFilter.Text))
                                {
                                    continue;
                                }
                            }
                            k++;
                            string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);
                            srcfileName = desfolderdir + "\\" + AppendDIRname + DateTime.Now.ToString("ddMMyyHHmmssms") + k + srcfileName;
                            Directory.CreateDirectory(desfolderdir);
                            if (chkRmoveSameFile.Checked)
                            {
                                if (File.Exists(srcfileName))
                                {
                                    File.Delete(srcfileName);
                                    txtstatus.AppendText(Environment.NewLine + "Duplication Detected File: " + srcfileName + " Removed.");
                                    continue;
                                }
                            }
                            if (!File.Exists(srcfileName))
                            {
                                File.Copy(file, srcfileName);
                            }

                        }//foreach
                        pBar.Invoke((MethodInvoker)delegate {
                            if (pBar.Maximum < 1)
                            {
                                pBar.Maximum = gCount;
                            }
                            pBar.Value = 1;
                        });
                        //pBar.Value = (int)(((double)i / checkedListBox.CheckedItems.Count) * 100);

                    }
                }

            }
        }

        private void btnCreateZip_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtdir.Text))
            {
                return;
            }
            btnCreateZip.Enabled = false;
            btnNewProcess.Enabled = true;
            
            var worker1 = new BackgroundWorker { WorkerReportsProgress = true };
            DoWorkEventHandler doWork = (snd, ev) =>
            {
                CreateZipFils();
            };
            worker1.DoWork += doWork;
            worker1.RunWorkerCompleted += (snd, ev) => { btnCreateZip.Enabled = true; };
            //worker1.ProgressChanged += (snd, ev) =>
            //{
            //    pBar.Value = ev.ProgressPercentage;
            //};
            worker1.WorkerReportsProgress = true;
            worker1.WorkerSupportsCancellation = true;
            worker1.RunWorkerAsync();
        }

        public void CreateZipFils() {

            Label label = new Label();
            label.Text = "Zipping Files: " + txtdir.Text;
            //label.Text = "Coping Files";
            label.Dock = DockStyle.Top;
            label.Font = new Font("Microsoft Sans Serif", 9);

            ProgressBar pBar = new ProgressBar();
            pBar.Location = new Point(20, 20);
            pBar.Name = "prg_" + txtdir.Text;
            pBar.Width = 200;
            pBar.Height = 20;
            pBar.Dock = DockStyle.Top;
            pBar.Minimum = 0;
            pBar.Maximum = 0;

            panel1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                panel1.Controls.Add(label);
                panel1.Controls.Add(pBar);

            });

            int count = 1, i = 0, checkedItemCount = 0, remainingZip = 0, TotalitemRun = 0;

            string folderName = txtsrc.Text.Substring(txtsrc.Text.LastIndexOf("\\") + 1);
            string targetDir = txtdir.Text + "\\";// + folderName;
            string AppendDIRname = "";
            //txtstatus.AppendText("Creating zip file Please wait...");
            string tempPath = Path.GetTempPath();
            string tempMainTargetDir = tempPath + "\\FileCopier " + DateTime.Now.ToString("ddMMyyHHmmssms");

            if (Directory.Exists(tempMainTargetDir))
            {
                Directory.Delete(tempMainTargetDir, true);
            }
            Directory.CreateDirectory(tempMainTargetDir);
            if (checkBoxwithoutDisplay.Checked)
            {
                string dirName = "";
                string fileName = "";
                string targetPath = "";
                string destFile = "";
                foreach (string dir in CreateBlockingCollection(chkIsfile.Checked, 0, txtSearchtext.Text, Convert.ToInt16((String.IsNullOrEmpty(txtFileLimit.Text) || String.IsNullOrWhiteSpace(txtFileLimit.Text)) ? "0" : txtFileLimit.Text)))
                {
                    checkedItemCount = gCount;
                    TotalitemRun++;
                    string[] dirnames = dir.Split(':');
                    dirnames = dirnames[1].Split('\\');
                    if (checkBoxCreateParent.Checked)
                    {
                        if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                        {
                            targetDir = txtdir.Text + "\\" + dirnames[Convert.ToInt16(txtPindex.Text)].ToString();
                        }
                    }
                    if (checkboxAppendName.Checked)
                    {
                        if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                        {
                            AppendDIRname = dirnames[Convert.ToInt16(txtPindex.Text)].ToString() + "_";
                        }
                    }
                    string itemDirName = dir.Substring(dir.LastIndexOf("\\") + 1);

                    //File.Copy(file, tempTargetDir);
                    string[] files = Directory.GetFiles(dir);
                    foreach (string file in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        dirName = dir.Substring(dir.LastIndexOf("\\") + 1);
                        fileName = file.Substring(file.LastIndexOf("\\") + 1);
                        targetPath = tempMainTargetDir + "\\" + itemDirName;
                        Directory.CreateDirectory(targetPath);
                        destFile = Path.Combine(targetPath, fileName);
                        File.Copy(file, destFile, true);
                    }

                    remainingZip = checkedItemCount - TotalitemRun;
                    if (count == Convert.ToInt16(txtSplitQty.Text) || remainingZip < Convert.ToInt16(txtSplitQty.Text))
                    {
                        i++;
                        //txtstatus.AppendText(Environment.NewLine + "Creating " + AppendDIRname + "Item" + i + ".zip");
                        //txtstatus.AppendText(Environment.NewLine + "Please wait...");
                        Directory.CreateDirectory(targetDir);
                        ZipFile.CreateFromDirectory(tempMainTargetDir, targetDir + "\\" + AppendDIRname + "Item" + i + ".zip");
                        count = 0;
                        Directory.Delete(tempMainTargetDir, true);
                        //txtstatus.AppendText(Environment.NewLine + "Zip File create successfully: " + AppendDIRname + "Item" + i + ".zip");
                    }
                    count++;
                    pBar.Invoke((MethodInvoker)delegate {
                        if (pBar.Maximum < 1)
                        {
                            pBar.Maximum = gCount;
                        }
                        pBar.Value = TotalitemRun;
                    });
                }
            }
            else
            {
                foreach (string dir in checkedListBox.CheckedItems)
                {
                    checkedItemCount = checkedListBox.CheckedItems.Count;
                    TotalitemRun++;
                    string[] dirnames = dir.Split(':');
                    dirnames = dirnames[1].Split('\\');
                    if (checkBoxCreateParent.Checked)
                    {
                        if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                        {
                            targetDir = txtdir.Text + "\\" + dirnames[Convert.ToInt16(txtPindex.Text)].ToString();
                        }
                    }
                    if (checkboxAppendName.Checked)
                    {
                        if (!String.IsNullOrEmpty(txtPindex.Text) || !String.IsNullOrWhiteSpace(txtPindex.Text))
                        {
                            AppendDIRname = dirnames[Convert.ToInt16(txtPindex.Text)].ToString() + "_";
                        }
                    }
                    string itemDirName = dir.Substring(dir.LastIndexOf("\\") + 1);

                    //File.Copy(file, tempTargetDir);
                    string[] files = Directory.GetFiles(dir);
                    foreach (string file in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string dirName = dir.Substring(dir.LastIndexOf("\\") + 1);
                        string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                        string targetPath = tempMainTargetDir + "\\" + itemDirName;
                        Directory.CreateDirectory(targetPath);
                        string destFile = Path.Combine(targetPath, fileName);
                        File.Copy(file, destFile, true);
                    }

                    remainingZip = checkedItemCount - TotalitemRun;
                    if (count == Convert.ToInt16(txtSplitQty.Text) || remainingZip < Convert.ToInt16(txtSplitQty.Text))
                    {
                        i++;
                        //txtstatus.AppendText(Environment.NewLine + "Creating " + AppendDIRname + "Item" + i + ".zip");
                        //txtstatus.AppendText(Environment.NewLine + "Please wait...");
                        Directory.CreateDirectory(targetDir);
                        ZipFile.CreateFromDirectory(tempMainTargetDir, targetDir + "\\" + AppendDIRname + "Item" + i + ".zip");
                        count = 0;
                        Directory.Delete(tempMainTargetDir, true);
                        //txtstatus.AppendText(Environment.NewLine + "Zip File create successfully: " + AppendDIRname + "Item" + i + ".zip");
                    }
                    count++;
                    pBar.Invoke((MethodInvoker)delegate {
                        if (pBar.Maximum < 1)
                        {
                            pBar.Maximum = checkedItemCount;
                        }
                        pBar.Value = TotalitemRun;
                    });
                }
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked == true)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, true);
                }
                checkBoxSelectAll.Text = "Unselect All";
            }
            else
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, false);
                }
                checkBoxSelectAll.Text = "Select All";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = checkedListBox.Items.Count;
            for (int index = count; index > 0; index--)
            {
                if (checkedListBox.CheckedItems.Contains(checkedListBox.Items[index - 1]))
                {
                    checkedListBox.Items.RemoveAt(index - 1);
                }
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtdir.Text))
            {
                return;
            }
            btnCSV.Enabled = false;
            btnNewProcess.Enabled = true;
            
            var worker1 = new BackgroundWorker { WorkerReportsProgress = true };
            DoWorkEventHandler doWork = (snd, ev) =>
            {
                CreateCSV();
            };
            worker1.DoWork += doWork;
            worker1.RunWorkerCompleted += (snd, ev) => { btnCSV.Enabled = true; };
            //worker1.ProgressChanged += (snd, ev) =>
            //{
            //    pBar.Value = ev.ProgressPercentage;
            //};
            worker1.WorkerReportsProgress = true;
            worker1.WorkerSupportsCancellation = true;
            worker1.RunWorkerAsync();
            MessageBox.Show("Process complete Please check.");
        }

        public void CreateCSV() {

            Label label = new Label();
            label.Text = "Creating CSV File: " + txtdir.Text;
            //label.Text = "Coping Files";
            label.Dock = DockStyle.Top;
            label.Font = new Font("Microsoft Sans Serif", 9);

            ProgressBar pBar = new ProgressBar();
            pBar.Location = new Point(20, 20);
            pBar.Name = "prg_" + txtdir.Text;
            pBar.Width = 200;
            pBar.Height = 20;
            pBar.Dock = DockStyle.Top;
            pBar.Minimum = 0;
            pBar.Maximum = 0;

            panel1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                panel1.Controls.Add(label);
                panel1.Controls.Add(pBar);

            });

            var csv = new StringBuilder();
            var newLine = string.Format("filename,dc.title,dc.contributor.author,dc.date.issued,dc.description.abstract,dc.subject");
            csv.AppendLine(newLine);

            string desfolderdir = txtdir.Text;
            int count = 0;
            if (checkBoxwithoutDisplay.Checked)
            {
                if (txtsrc.Text != "")
                {
                    //var txtFiles = Directory.EnumerateDirectories(txtsrc.Text, (String.IsNullOrEmpty(txtPattern.Text) || txtPattern.Text == "i.e (*.pdf)" ? "*.*" : txtPattern.Text), (checkBoxGetSubdirs.Checked ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories)).AsParallel();
                    foreach (string file in CreateBlockingCollection(chkIsfile.Checked ? true : false, 0, "", Convert.ToInt16((String.IsNullOrEmpty(txtFileLimit.Text) || String.IsNullOrWhiteSpace(txtFileLimit.Text)) ? "0" : txtFileLimit.Text)))
                    {
                        count++;
                        try
                        {
                            string subject = Regex.Replace(HtmlFilter.ConvertToPlainText(File.ReadAllText(file)).Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("   ", " ").Trim(), @"\s+", " ");
                            subject = subject.Length >= 100 ? subject.Substring(0, 100) : subject;
                            string filename = file.Substring(file.LastIndexOf("\\") + 1);
                            string title = subject;
                            string author = "Patent";
                            string date = File.GetCreationTime(file).ToString("dd-MM-yyyy");
                            string abstractDes = Regex.Replace(HtmlFilter.ConvertToPlainText(File.ReadAllText(file)).Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("   ", " ").Replace("\"", "'"), @"\s+", " ");
                            if (String.IsNullOrWhiteSpace(abstractDes.Trim()) || abstractDes.Length < 100)
                            {
                                txtstatus.Invoke((MethodInvoker)delegate
                                {
                                    txtstatus.AppendText(Environment.NewLine + "File: \"" + file + "\" has not sufficient Text to read. File removed from the collection. Please see the unsufficient Directory");

                                });
                                Directory.CreateDirectory(desfolderdir + "\\ unsufficient");
                                if (!File.Exists(desfolderdir + "\\ unsufficient \\" + file.Substring(file.LastIndexOf("\\") + 1)))
                                {
                                    File.Copy(file, desfolderdir + "\\ unsufficient \\" + file.Substring(file.LastIndexOf("\\") + 1));
                                }
                                File.Delete(file);
                                continue;
                            }
                            //abstractDes = abstractDes.Length >= 32000 ? abstractDes.Substring(0, 32000) : abstractDes;

                            newLine = string.Format($"\"{filename}\",\"{title}\",{author},{date},\"{abstractDes}\",\"{subject}\"");
                            csv.AppendLine(newLine);
                        }
                        catch (Exception ex)
                        {
                            Directory.CreateDirectory(desfolderdir + "\\ Error Files");
                            if (!File.Exists(desfolderdir + "\\ Error Files \\" + file.Substring(file.LastIndexOf("\\") + 1)))
                            {
                                File.Copy(file, desfolderdir + "\\ Error Files \\" + file.Substring(file.LastIndexOf("\\") + 1));
                            }
                            File.Delete(file);
                            txtstatus.Invoke((MethodInvoker)delegate {
                                txtstatus.AppendText(Environment.NewLine + "Error in file: " + file + Environment.NewLine + "Exception: " + ex + Environment.NewLine + "File Moved in " + desfolderdir + "\\ Error Files \\" + file.Substring(file.LastIndexOf("\\") + 1));
                            });
                        }

                        pBar.Invoke((MethodInvoker)delegate {
                            if (pBar.Maximum < 1)
                            {
                                pBar.Maximum = gCount;
                            }
                            pBar.Value = count;
                        });
                    }
                }
            }
            else
            {
                foreach (string file in checkedListBox.CheckedItems)
                {
                    count++;
                    try
                    {
                        string subject = Regex.Replace(HtmlFilter.ConvertToPlainText(File.ReadAllText(file)).Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("   ", " ").Trim(), @"\s+", " ");
                        subject = subject.Length >= 100 ? subject.Substring(0, 100) : subject;
                        string filename = file.Substring(file.LastIndexOf("\\") + 1);
                        string title = subject;
                        string author = "Patent";
                        string date = File.GetCreationTime(file).ToString("dd-MM-yyyy");
                        string abstractDes = Regex.Replace(HtmlFilter.ConvertToPlainText(File.ReadAllText(file)).Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("   ", " ").Replace("\"", "'"), @"\s+", " ");
                        if (String.IsNullOrWhiteSpace(abstractDes.Trim()) || abstractDes.Length < 100)
                        {
                            txtstatus.Invoke((MethodInvoker)delegate
                            {
                                txtstatus.AppendText(Environment.NewLine + "File: \"" + file + "\" has not sufficient Text to read. File removed from the collection. Please see the unsufficient Directory");

                            });
                            Directory.CreateDirectory(desfolderdir + "\\ unsufficient");
                            if (!File.Exists(desfolderdir + "\\ unsufficient \\" + file.Substring(file.LastIndexOf("\\") + 1)))
                            {
                                File.Copy(file, desfolderdir + "\\ unsufficient \\" + file.Substring(file.LastIndexOf("\\") + 1));
                            }
                            File.Delete(file);
                            continue;
                        }
                        //abstractDes = abstractDes.Length >= 32000 ? abstractDes.Substring(0, 32000) : abstractDes;
                        newLine = string.Format($"\"{filename}\",\"{title}\",{author},{date},\"{abstractDes}\",\"{subject}\"");
                        csv.AppendLine(newLine);
                    }
                    catch (Exception ex)
                    {
                        Directory.CreateDirectory(desfolderdir + "\\ Error Files");
                        if (!File.Exists(desfolderdir + "\\ Error Files \\" + file.Substring(file.LastIndexOf("\\") + 1)))
                        {
                            File.Copy(file, desfolderdir + "\\ Error Files \\" + file.Substring(file.LastIndexOf("\\") + 1));
                        }
                        File.Delete(file);
                        txtstatus.Invoke((MethodInvoker)delegate {
                            txtstatus.AppendText(Environment.NewLine + "Error in file: " + file + Environment.NewLine + "Exception: " + ex + Environment.NewLine + "File Moved in " + desfolderdir + "\\ Error Files \\" + file.Substring(file.LastIndexOf("\\") + 1));
                        });
                    }
                    pBar.Invoke((MethodInvoker)delegate {
                        if (pBar.Maximum < 1)
                        {
                            pBar.Maximum = gCount;
                        }
                        pBar.Value = count;
                    });
                }//foreach
            }
            File.WriteAllText(desfolderdir + "\\Patent.csv", csv.ToString());
        }

        private void btnSearchText_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var currentFile in CreateBlockingCollection(true, 0, txtSearchtext.Text,Convert.ToInt16((String.IsNullOrEmpty(txtFileLimit.Text) || String.IsNullOrWhiteSpace(txtFileLimit.Text)) ? "0" : txtFileLimit.Text)))
            {
                string fileName = currentFile.Substring(txtsrc.Text.Length + 1);
                string path = txtsrc.Text;

                checkedListBox.DisplayMember = fileName;
                checkedListBox.ValueMember = txtsrc.Text;
                checkedListBox.Items.Insert(i, path + "\\" + fileName);
                checkedListBox.SetItemChecked(i, true);
                txtstatus.AppendText(Environment.NewLine + i + ": " + path + "\\" + fileName);
                i++;
            }
        }

        private void chkRmoveSameFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSplitQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewProcess_Click(object sender, EventArgs e)
        {
            btnCSV.Enabled = true;
            btnCreateZip.Enabled = true;
            bntCopyFileInlist.Enabled = true;
            MessageBox.Show("New process created.");
        }

        private void btndesdir_Click(object sender, EventArgs e)
        {
            using (var fbd2 = new FolderBrowserDialog())
            {
                DialogResult result = fbd2.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd2.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd2.SelectedPath);
                    txtdir.Text = fbd2.SelectedPath;
                    dirPath = txtdir.Text;
                    //lbldir.Text = "File lenght " + files.Length.ToString();
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            CopyDirectory(srcPath, dirPath);
            Console.WriteLine("Data Copeid at {0}", e.SignalTime);
            status = "Data Copeid at {0}"+ e.SignalTime.ToString();
            stxtstatus = status;
            //check(status);
        }

        //public void check(string a)
        //{
        //    txtstatus.Text = stxtstatus;

        //}

    }
}
