using ResultCompareUI.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultCompareUI
{
    public partial class MainForm : Form
    {
        private string createFolderPathName = "";
        private const string pathConfig = ".\\config";
        private const string pathWorking = ".\\working";
        private RCCompareResult readResult;

        private bool fromUDFCompare = false;
        public string udfCompareQuery1 = "";
        public string udfCompareQuery2 = "";        

        /// <summary>
        ///  -1 default value
        ///  0 compare list
        ///  1 manual compare list
        /// </summary>
        private int lastDisplayType = -1;

        private const string ignoreList = "Ignore List";
        private const string compareList = "Compare List";
        private const string manualCompareList = "Manual Query Compare List";

        public MainForm()
        {
            InitializeComponent();
            RCConfigurationList.GetList();
            readResult = new RCCompareResult();
            RCLogMessage.Instance().SetBox(mLBLog);
        }

        private void mButtonBrz_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Path.GetFullPath(pathConfig);
            dialog.Multiselect = false;
            dialog.Title = "Select";
            dialog.Filter = "Ingore File|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mTBIgnorePath.Text = dialog.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RCQueryBox.Init(ConfigurationDBType.C_HANA);
            InitBusinessObjectComboBox();
            InitBusinessObjectSubTable();
            InitIgnoreListFilePath();
            InitCompareList();
        }

        private void InitBusinessObjectComboBox()
        {
            mCBBO.Items.AddRange(RCQueryBox.GetAllBO());
            mCBBO.Text = mCBBO.Items[0].ToString();
        }

        private void InitBusinessObjectSubTable()
        {
            MatchBOWithSubTables(mCBBO.Text);
        }

        private void InitIgnoreListFilePath()
        {
            DirectoryInfo root = new DirectoryInfo(Path.GetFullPath(pathConfig));
            FileInfo[] files = root.GetFiles();
            foreach(var fi in files)
            {
                if (fi.Name == "ignore.txt")
                {
                    mTBIgnorePath.Text = fi.FullName;
                    return;
                }
            }
        }

        private void InitCompareList()
        {
            mDGVCompareList.ReadOnly = true;
            mDGVCompareList.AllowUserToAddRows = false;
            mDGVCompareList.AutoGenerateColumns = false;
            mDGVCompareList.RowHeadersVisible = false;            
        }

        private bool CheckReady()
        {
            if (mTBLeftKey.Text.Length == 0 || mTBRightKey.Text.Length == 0)
                return false;
            return true;
        }

        private void CreateClickFolder()
        {
            DateTime dt = DateTime.Now;
            string strDT = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
            createFolderPathName = pathWorking + "\\" + strDT;
            RCComand.Cmd("mkdir " + createFolderPathName);
            saveToolStripMenuItem.Enabled = true;
        }

        private string getLeftSqlFilePathName(int checkIndex)
        {
            return createFolderPathName + "\\L_" + mTBLeftKey.Text + "_" + (mLVSubTable.CheckedItems[checkIndex].Text) +".SQL";
        }

        private string getLeftSqlFilePathName()
        {
            return createFolderPathName + "\\L_.SQL";
        }

        private string getRightSqlFilePathName(int checkIndex)
        {
            return createFolderPathName + "\\R_" + mTBRightKey.Text + "_" + (mLVSubTable.CheckedItems[checkIndex].Text) + ".SQL";
        }

        private string getRightSqlFilePathName()
        {
            return createFolderPathName + "\\R_.SQL";
        }

        private string getLeftRetrieveFileName(int checkIndex)
        {
            return createFolderPathName + "\\L_" + mTBLeftKey.Text +  "_" + (mLVSubTable.CheckedItems[checkIndex].Text) + ".RST";
        }

        private string getLeftRetrieveFileName()
        {
            return createFolderPathName + "\\L_.RST";
        }

        private string getRightRetrieveFileName(int checkIndex)
        {
            return createFolderPathName + "\\R_" + mTBRightKey.Text + "_" + (mLVSubTable.CheckedItems[checkIndex].Text) +".RST"; 
        }

        private string getRightRetrieveFileName()
        {
            return createFolderPathName + "\\R_.RST";
        }

        private string getCompareResultFileName(int checkIndex)
        {
            return createFolderPathName + "\\O_" + (mLVSubTable.CheckedItems[checkIndex].Text) + "_" + mTBLeftKey.Text + "_" + mTBRightKey.Text + ".TXT"; 
        }

        private string getCompareResultFileName()
        {
            return createFolderPathName + "\\O_.TXT";
        }

        private void CreateSqlFiles_HANA()
        {
            // order by xxx;
            for (int i = 0; i < mLVSubTable.CheckedItems.Count; ++i)
            {
                string exeCmdL = "echo set Schema \"" + RCConfigurationList.GetCurrent().GetSchema() + "\";" +
                    RCQueryBox.GetQueryByBOTable(mCBBO.Text, mLVSubTable.CheckedItems[i].Text, mTBLeftKey.Text);
                
                exeCmdL += " > \"" + getLeftSqlFilePathName(i) +"\"";
                RCComand.Cmd(exeCmdL);

                mProgBar.Value += 1;

                string exeCmdR = "echo set Schema \"" + RCConfigurationList.GetCurrent().GetSchema() + "\";" +
                    RCQueryBox.GetQueryByBOTable(mCBBO.Text, mLVSubTable.CheckedItems[i].Text, mTBRightKey.Text);

                exeCmdR += " > \"" + getRightSqlFilePathName(i) + "\"";
                RCComand.Cmd(exeCmdR);

                mProgBar.Value += 1;
            }
        }

        private void CreateSqlFiles_MSSQL()
        {
            // order by xxx;
            for (int i = 0; i < mLVSubTable.CheckedItems.Count; ++i)
            {
                string exeCmdL = "echo " + 
                    RCQueryBox.GetQueryByBOTable(mCBBO.Text, mLVSubTable.CheckedItems[i].Text, mTBLeftKey.Text);

                exeCmdL += " > \"" + getLeftSqlFilePathName(i) + "\"";
                RCComand.Cmd(exeCmdL);

                mProgBar.Value += 1;

                string exeCmdR = "echo " + 
                    RCQueryBox.GetQueryByBOTable(mCBBO.Text, mLVSubTable.CheckedItems[i].Text, mTBRightKey.Text);

                exeCmdR += " > \"" + getRightSqlFilePathName(i) + "\"";
                RCComand.Cmd(exeCmdR);

                mProgBar.Value += 1;
            }
        }

        private void CreateSqlFilesByManualQuery_HANA()
        {
            string exeCmdL = "echo set Schema \"" + RCConfigurationList.GetCurrent().GetSchema() + "\";" + udfCompareQuery1;
            exeCmdL += " > \"" + getLeftSqlFilePathName() + "\"";
            RCComand.Cmd(exeCmdL);
            mProgBar.Value += 1;

            string exeCmdR = "echo set Schema \"" + RCConfigurationList.GetCurrent().GetSchema() + "\";" + udfCompareQuery2;
            exeCmdR += " > \"" + getRightSqlFilePathName() + "\"";
            RCComand.Cmd(exeCmdR);
            mProgBar.Value += 1;
        }

        private void CreateSqlFilesByManualQuery_MSSQL()
        {
            string exeCmdL = "echo " + udfCompareQuery1;
            exeCmdL += " > \"" + getLeftSqlFilePathName() + "\"";
            RCComand.Cmd(exeCmdL);
            mProgBar.Value += 1;

            string exeCmdR = "echo " + udfCompareQuery2;
            exeCmdR += " > \"" + getRightSqlFilePathName() + "\"";
            RCComand.Cmd(exeCmdR);
            mProgBar.Value += 1;
        }

        private void RetrieveSqlResult_HANA()
        {
            string hdbsql = "\"" + RCConfigurationList.GetCurrent().configurationExePath + "\"";
            for (int i = 0; i < mLVSubTable.CheckedItems.Count; ++i)
            {
                string exeCmdL = hdbsql + " -n " + RCConfigurationList.GetCurrent().GetIPPort() + " -u " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -p " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + "DBA" + " -I " + "\"" + getLeftSqlFilePathName(i) + "\"" +
                    " -o " + "\"" + getLeftRetrieveFileName(i) + "\"" +
                    " -connecttimeout " + RCConfigurationList.GetCurrent().GetConnectionTimout();
                RCComand.Cmd(exeCmdL);

                mProgBar.Value += 1;

                string exeCmdR = hdbsql + " -n " + RCConfigurationList.GetCurrent().GetIPPort() + " -u " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -p " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + "DBA" + " -I " + "\"" + getRightSqlFilePathName(i) + "\"" +
                    " -o " + "\"" + getRightRetrieveFileName(i) + "\"" +
                    " -connecttimeout " + RCConfigurationList.GetCurrent().GetConnectionTimout();
                RCComand.Cmd(exeCmdR);

                mProgBar.Value += 1;
            }
        }

        private void RetrieveSqlResult_MSSQL()
        {
            string hdbsql = "\"" + RCConfigurationList.GetCurrent().configurationExePath + "\"";
            for (int i = 0; i < mLVSubTable.CheckedItems.Count; ++i)
            {
                string exeCmdL = hdbsql + " -S " + RCConfigurationList.GetCurrent().GetIPPort() + " -U " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -P " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + RCConfigurationList.GetCurrent().GetSchema() + " -i " + "\"" + getLeftSqlFilePathName(i) + "\"" +
                    " -o " + "\"" + getLeftRetrieveFileName(i) + "\"" +
                    " -t " + RCConfigurationList.GetCurrent().GetConnectionTimout() +
                    " -k2 ";
                RCComand.Cmd(exeCmdL);

                mProgBar.Value += 1;

                string exeCmdR = hdbsql + " -S " + RCConfigurationList.GetCurrent().GetIPPort() + " -U " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -P " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + RCConfigurationList.GetCurrent().GetSchema() + " -i " + "\"" + getRightSqlFilePathName(i) + "\"" +
                    " -o " + "\"" + getRightRetrieveFileName(i) + "\"" +
                    " -t " + RCConfigurationList.GetCurrent().GetConnectionTimout() +
                    " -k2 ";
                RCComand.Cmd(exeCmdR);

                mProgBar.Value += 1;
            }
        }

        private void RetrieveSqlResultByManualQuery_HANA()
        {
            string hdbsql = "\"" + RCConfigurationList.GetCurrent().configurationExePath + "\"";
            string exeCmdL = hdbsql + " -n " + RCConfigurationList.GetCurrent().GetIPPort() + " -u " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -p " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + "DBA" + " -I " + "\"" + getLeftSqlFilePathName() + "\"" +
                    " -o " + "\"" + getLeftRetrieveFileName() + "\"" +
                    " -connecttimeout " + RCConfigurationList.GetCurrent().GetConnectionTimout();
            RCComand.Cmd(exeCmdL);

            mProgBar.Value += 1;

            string exeCmdR = hdbsql + " -n " + RCConfigurationList.GetCurrent().GetIPPort() + " -u " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -p " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + "DBA" + " -I " + "\"" + getRightSqlFilePathName() + "\"" +
                    " -o " + "\"" + getRightRetrieveFileName() + "\"" +
                    " -connecttimeout " + RCConfigurationList.GetCurrent().GetConnectionTimout();
            RCComand.Cmd(exeCmdR);

            mProgBar.Value += 1;
        }

        private void RetrieveSqlResultByManualQuery_MSSQL()
        {
            string sqlcmd = "\"" + RCConfigurationList.GetCurrent().configurationExePath + "\"";
            string exeCmdL = sqlcmd + " -S " + RCConfigurationList.GetCurrent().GetIPPort() + " -U " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -P " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + RCConfigurationList.GetCurrent().GetSchema() + " -i " + "\"" + getLeftSqlFilePathName() + "\"" +
                    " -o " + "\"" + getLeftRetrieveFileName() + "\"" +
                    " -t " + RCConfigurationList.GetCurrent().GetConnectionTimout() + 
                    " -k2 ";
            RCComand.Cmd(exeCmdL);

            mProgBar.Value += 1;

            string exeCmdR = sqlcmd + " -S " + RCConfigurationList.GetCurrent().GetIPPort() + " -U " + RCConfigurationList.GetCurrent().GetUserName() +
                    " -P " + RCConfigurationList.GetCurrent().GetPassword() + " -d " + RCConfigurationList.GetCurrent().GetSchema() + " -i " + "\"" + getRightSqlFilePathName() + "\"" +
                    " -o " + "\"" + getRightRetrieveFileName() + "\"" +
                    " -t " + RCConfigurationList.GetCurrent().GetConnectionTimout() + 
                    " -k2 ";
            RCComand.Cmd(exeCmdR);

            mProgBar.Value += 1;
        }

        private void ConvertRSTFiles_MSSQL()
        {
            var files = Directory.GetFiles(createFolderPathName, "*.RST");
            foreach(var file in files)
            {
                RCMSSQLConverter.Convert(file);
            }
        }

        private Dictionary<string, string> ReadIgnoreFile()
        {
            Dictionary<string, string> ignoreFiles = new Dictionary<string,string>();
            StreamReader sr = new StreamReader(mTBIgnorePath.Text, Encoding.Default);
            try
            {
                
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> parts = line.Split(':').ToList();
                    if (parts.Count > 1)
                    {
                        ignoreFiles[parts[0]] = parts[1];
                    }
                    else
                    {
                        // todo report error;
                    }
                }
            }
            catch(Exception)
            {
                RCLogMessage.Instance().Log("Take care of that IgnoreFile is empty");
            }

            finally
            {
                sr.Close();
            }
          
            return ignoreFiles;
        }

        private void CompareSqlResult()
        {
            Dictionary<string, string> ignoreFiles = ReadIgnoreFile();
            for (int i = 0; i < mLVSubTable.CheckedItems.Count; ++i)
            {
                string tableName = mLVSubTable.CheckedItems[i].Text;

                try
                {
                   // string exeCmd = "DBCompare compare" +
                   //" -l " + "\"" + getLeftRetrieveFileName(i) + "\"" +
                   //" -r " + "\"" + getRightRetrieveFileName(i) + "\"" +
                   //" -o " + "\"" + getCompareResultFileName(i) + "\"";

                   // string tableKeyOrder = QueryBox.GetTableKeyOrderByBOTable(mCBBO.Text, tableName);
                   // if (tableKeyOrder != null)
                   // {
                   //     exeCmd += " -k " + tableKeyOrder;
                   // }

                   // if (ignoreFiles.ContainsKey(tableName))
                   // {
                   //     exeCmd += " -I " + ignoreFiles[tableName] + IgnoreAlready.GetByTable(tableName);
                   // }

                   // Command.Cmd(exeCmd, mLBLog);

                    string ignoreStr = "";
                    if (ignoreFiles.ContainsKey(tableName))
                    {
                        ignoreStr += ignoreFiles[tableName] + RCIgnoreAlready.GetByTable(tableName);
                    }

                    RCCompareFileGenenrator cFileGen = new RCCompareFileGenenrator();
                    cFileGen.GenerateOFile(
                        getLeftRetrieveFileName(i),
                        getRightRetrieveFileName(i),
                        ignoreStr,
                        RCQueryBox.GetTableKeyOrderByBOTable(mCBBO.Text, tableName),
                        getCompareResultFileName(i)
                        );
                }
                catch(Exception ex)
                {
                    RCLogMessage.Instance().Log(ex.Message);
                }                

                mProgBar.Value += 1;
            }           
        }

        private void CompareSqlResultByManualQuery()
        {
            string exeCmd = "DBCompare compare" +
                 " -l " + "\"" + getLeftRetrieveFileName() + "\"" +
                 " -r " + "\"" + getRightRetrieveFileName() + "\"" +
                 " -o " + "\"" + getCompareResultFileName() + "\"";
            RCComand.Cmd(exeCmd);
        }
        
        public void DBCompareCombination()
        {
            CreateClickFolder();
            if (RCConfigurationList.GetCurrent().GetDBType() == ConfigurationDBType.C_HANA)
            {
                CreateSqlFiles_HANA();
                RetrieveSqlResult_HANA();
            }
            else if (RCConfigurationList.GetCurrent().GetDBType() == ConfigurationDBType.C_MSSQL)
            {
                CreateSqlFiles_MSSQL();
                RetrieveSqlResult_MSSQL();
                ConvertRSTFiles_MSSQL();
            }
            else
            {
                RCLogMessage.Instance().Log("Invalid DB Type");
                return;
            }
            
            CompareSqlResult();
        }

        public void DBCompareCombinationAdvanced()
        {
            CreateClickFolder();
            if (RCConfigurationList.GetCurrent().GetDBType() == ConfigurationDBType.C_HANA)
            {
                CreateSqlFilesByManualQuery_HANA();
                RetrieveSqlResultByManualQuery_HANA();
            }
            else if (RCConfigurationList.GetCurrent().GetDBType() == ConfigurationDBType.C_MSSQL)
            {
                CreateSqlFilesByManualQuery_MSSQL();
                RetrieveSqlResultByManualQuery_MSSQL();
                ConvertRSTFiles_MSSQL();
            }
            else
            {
                RCLogMessage.Instance().Log("Invalid DB Type");
                return;
            }
            CompareSqlResultByManualQuery();
        }

        private RCCompareResult ReadCompareResult()
        {
            RCCompareResult compareResult = new RCCompareResult();
            StreamReader sr = null;
            try
            {
                for (int i = 0; i < mLVSubTable.CheckedItems.Count; ++i)
                {
                    using (sr = new StreamReader(getCompareResultFileName(i), Encoding.Default))
                    {
                        CompareTable ct = new CompareTable(mLVSubTable.CheckedItems[i].Text);
                        string line;
                        for (int cursor = 0; (line = sr.ReadLine()) != null; ++cursor)
                        {
                            if (cursor == 0)
                            {
                                ct.docCols = CompareTable.TrimLine(line);
                            }
                            else
                            {

                                ct.docValues.Add(CompareTable.TrimLine(line));
                            }
                        }
                        compareResult.tableGroup.Add(ct);
                    }                   
                }
            }
            catch(Exception ex)
            {
                RCLogMessage.Instance().Log(ex.Message);
            }
            finally
            {
                //if (sr != null)
                //    sr.Close();
            }

            return compareResult;
        }

        private RCCompareResult ReadManualCompareResult()
        {
            RCCompareResult compareResult = new RCCompareResult();
            StreamReader sr = null;
            try
            {
                    sr = new StreamReader(getCompareResultFileName(), Encoding.Default);
                    CompareTable ct = new CompareTable("ManualQuery");
                    string line;
                    for (int cursor = 0; (line = sr.ReadLine()) != null; ++cursor)
                    {
                        if (cursor == 0)
                        {
                            ct.docCols = CompareTable.TrimLine(line);
                        }
                        else
                        {

                            ct.docValues.Add(CompareTable.TrimLine(line));
                        }
                    }
                    compareResult.tableGroup.Add(ct);
            }
            catch (Exception ex)
            {
                RCLogMessage.Instance().Log(ex.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return compareResult;
        }


        // default        0
        // manually query 1
        private void CompareResultDisplay(int displayType = 0)
        {

            mDGVCompareList.Columns.Clear();
            mDGVCompareList.Rows.Clear();

            if (mRBShowCompare.Checked)
            {
                if (displayType == 0)
                {
                    mLBCompareList.Text = compareList;
                    readResult = ReadCompareResult();
                }
                else if (displayType == 1)
                {
                    mLBCompareList.Text = manualCompareList;
                    readResult = ReadManualCompareResult();
                }
            }
            else
            {
                mLBCompareList.Text = compareList;
                return;
            }

            // empty hide
            //if (readResult.IsEmpty() && (displayType == 0 || displayType == 1))
            //{
            //    mDGVCompareList.Hide();
            //}
            //else
            //{
            //    mDGVCompareList.Show();
            //}
                
            int maxCount = readResult.GetMaxColumnCount();

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(mDGVCompareList);
            DataGridViewTextBoxCell cellStyle = new DataGridViewTextBoxCell();

            for (int i =0; i < maxCount; ++i)
            {
                DataGridViewColumn headerCol = new DataGridViewColumn(cellStyle);
                mDGVCompareList.Columns.Add(headerCol);
            }

            int lineNum = 0;
            foreach(var ct in readResult.tableGroup)
            {
                List<List<string>> content = ct.FormatTableContent();
                foreach(var words in content)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    mDGVCompareList.Rows.Add(newRow);
                    mDGVCompareList.Rows[lineNum++].SetValues(words.ToArray());
                }
            }


            // todo

            Font nameFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            Font tableKeyFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            Font tableHeaderFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            int startRowIndex = 0;
            foreach(var x in readResult.tableGroup)
            {
                for (int i = 0; i < x.formatedColsAndValuesType.Count; ++i)
                {
                    for (int j = 0; j < x.formatedColsAndValuesType[i].Count; ++j)
                    {
                        switch(x.formatedColsAndValuesType[i][j])
                        {
                            case CompareTable.TableName:
                                mDGVCompareList.Rows[i + startRowIndex].Cells[j].Style.Font = nameFont;
                                break;
                            case CompareTable.TableKey:
                                mDGVCompareList.Rows[i + startRowIndex].Cells[j].Style.BackColor = Color.Beige;
                                mDGVCompareList.Rows[i + startRowIndex].Cells[j].Style.Font = tableKeyFont;
                                break;
                            case CompareTable.TableHeader:
                                mDGVCompareList.Rows[i + startRowIndex].Cells[j].Style.BackColor = Color.Bisque;
                                mDGVCompareList.Rows[i + startRowIndex].Cells[j].Style.Font = tableHeaderFont;
                                break;
                            case CompareTable.TableKeyValue:
                                break;
                            default:
                                break;
                        }
                    }
                }

                startRowIndex += x.formatedColsAndValuesType.Count;
            }
        }

        private void mButtonCompare_Click(object sender, EventArgs e)
        {
            mLBLog.Items.Clear();
            if (!CheckReady())
            {
                RCLogMessage.Instance().Log("Compare Object Key is Empty, please input first.");
                return;
            }

            mProgBar.Show();
            mProgBar.Value = 0;
            mProgBar.Maximum = mLVSubTable.CheckedItems.Count * 5;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            RCQueryBox.Init(RCConfigurationList.GetCurrent().GetDBType());
            DBCompareCombination();
            CompareResultDisplay();
            lastDisplayType = 0;

            mLBCompareList.Text = compareList;
            mLBCompareList.Show();

            this.Cursor = System.Windows.Forms.Cursors.Arrow;

            mProgBar.Hide();

            if (mLBLog.Items.Count > 0)
                mLBLog.SelectedItem = mLBLog.Items[mLBLog.Items.Count - 1];
            mLBLog.ClearSelected();
        }

        private void MatchBOWithSubTables(string bo)
        {
            mLVSubTable.Items.Clear();
            string[] tables = RCQueryBox.GetTablesByBO(bo);
            for (int i = 0; i < tables.Count(); ++i )
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = tables[i];
                mLVSubTable.Items.Add(lvi);
            }

            mLVSubTable.Items[0].Checked = true;
        }

        private void MatchBOWithLabels(string bo)
        {
            mLB1.Text =
            RCQueryBox.GetTableKeyOrderByBOTable(bo, mLVSubTable.Items[0].Text).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList()[0];
            mLB2.Text =
            RCQueryBox.GetTableKeyOrderByBOTable(bo, mLVSubTable.Items[0].Text).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList()[0];
        }

        private void mComBoxBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbBO = sender as ComboBox;
            MatchBOWithSubTables((string)cbBO.SelectedItem);
            MatchBOWithLabels((string)cbBO.SelectedItem);
        }

        private void mCheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            
            for (int i = 0; i < mLVSubTable.Items.Count; ++i)
            {
                if (cb.Checked)
                {
                    mLVSubTable.Items[i].Checked = true;
                }
                else
                {
                    mLVSubTable.Items[i].Checked = false;
                }
                
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            mDGVCompareList.Width = this.Size.Width - 27 - mDGVCompareList.Location.X;
            mLine1.Width = this.Size.Width - 21 - mLine1.Location.X;
            mLine2.Width = this.Size.Width - 21 - mLine2.Location.X;
            mLBLog.Width = this.Size.Width - 27 - mLBLog.Location.X;

            mPBLogo.Location = new Point(this.Size.Width - 254, mPBLogo.Location.Y);
            mRBShowCompare.Location = new Point(this.Size.Width - 205, mRBShowCompare.Location.Y);
            mRBShowIgnore.Location = new Point(this.Size.Width - 114, mRBShowIgnore.Location.Y);

            mLVSubTable.Height = this.Size.Height - 207 - mLVSubTable.Location.Y;
            mDGVCompareList.Height = mLVSubTable.Height;
            mLine2.Location = new Point(mLine2.Location.X, mLVSubTable.Location.Y + mLVSubTable.Height + 14);            
            mProgBar.Location = new Point(this.Size.Width - 147, mLine2.Location.Y - 5);
            mLBLog.Location = new Point(mLBLog.Location.X, mLine2.Location.Y + 15);
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Owner = this;
            configForm.StartPosition = FormStartPosition.CenterParent;
            configForm.ShowInTaskbar = false;
            configForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "All Types|*.*";
                sfd.FileName = mLBCompareList.Text;
                sfd.DefaultExt = "csv";
                sfd.AddExtension = true;
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string content = "";
                    DirectoryInfo root = new DirectoryInfo(createFolderPathName);
                    FileInfo[] files = root.GetFiles();
                    foreach (var fi in files)
                    {
                        if (fi.Name.StartsWith("O_"))
                        {
                            sr = new StreamReader(fi.FullName);
                            content += fi.Name.Split('_').ToList()[1] + "\n";
                            content += sr.ReadToEnd().Replace(";", ", ,");
                        }
                    }

                    sw = new StreamWriter(sfd.FileName);
                    sw.Write(content);
                    RCLogMessage.Instance().Log("Save successfully, path \"" + sfd.FileName + "\"");
                }
            }
            catch(Exception ex)
            {
                RCLogMessage.Instance().Log(ex.Message);
            }   
            finally
            {
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
            }
        }

        private void mDGVCompareList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mDGVCompareList.ClearSelection();
            }
            
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                mDGVCompareList.CurrentRow.Selected = false;
                mDGVCompareList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }

            if (e.Button  == System.Windows.Forms.MouseButtons.Right 
                && mLBCompareList.Text == compareList)
            {
                if (readResult.GetCellType(e.ColumnIndex, e.RowIndex) == 2)
                {
                    IgnoreColumnTSM.Visible = true;
                }
                else
                {
                    IgnoreColumnTSM.Visible = false;
                }
                mDGVCompareListMenu.Show(MousePosition.X, MousePosition.Y);
            }

            if (e.Button  == System.Windows.Forms.MouseButtons.Right
                && mLBCompareList.Text == ignoreList
                && e.ColumnIndex > 0)
            {
                mDGVIgnoreListMenu.Show(MousePosition.X, MousePosition.Y);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right
                && mLBCompareList.Text == compareList
                && readResult.GetCellType(e.ColumnIndex, e.RowIndex) == 0)
            {
                mDGVCompareHeaderMenu.Show(MousePosition.X, MousePosition.Y);
            }

        }

        private void IgnoreColumnTSM_Click(object sender, EventArgs e)
        {
            string tableName = readResult.GetCellTableName(0 , 
                mDGVCompareList.SelectedCells[0].RowIndex).Trim();
            string columnName = readResult.GetCellColumnName(mDGVCompareList.SelectedCells[0].ColumnIndex, 
                mDGVCompareList.SelectedCells[0].RowIndex).Trim();

            try
            {
                string ignoreTxt = "";
                using (StreamReader sr = new StreamReader(mTBIgnorePath.Text))
                {
                    ignoreTxt = sr.ReadToEnd();
                }

                List<string> eachFiles = ignoreTxt.Split(("\r\n").ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                string outStr = "";
                bool found = false;
                foreach(var fi in eachFiles)
                {
                    outStr = outStr + fi.Trim();
                    List<string> fiParts = fi.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (fiParts.Count > 1 && fiParts[0].Trim() == tableName)
                    {
                        outStr = outStr.Trim() + "," + columnName;
                        found = true;
                    }
                    outStr += "\r\n";
                }

                if (!found)
                {
                    outStr += tableName + ":" + columnName + "\r\n";
                }


                StreamWriter sw = new StreamWriter(mTBIgnorePath.Text);
                sw.Write(outStr);
                sw.Close();

                // remove result in o file.
                DirectoryInfo di = new DirectoryInfo(createFolderPathName);
                FileInfo[] finfo = di.GetFiles();
                foreach(var fin in finfo)
                {
                    if (fin.Name.StartsWith("O_" + tableName + "_"))
                    {
                        string oContent = "";
                        int cur = 0;
                        // todo use docCol and docValues;
                        var readGroup = readResult.GetCompareTableByName(tableName);
                        List<string> parts = readGroup.docCols.Split(';').ToList();
                        if (parts.Count > 1)
                        {
                            oContent += parts[0] + ";";
                            List<string> cols = parts[1].Split(',').ToList();
                            for (int rec = 0; rec < cols.Count; ++rec )
                            {
                                if (cols[rec].Trim() != columnName)
                                {
                                    oContent += cols[rec] + ",";
                                }
                                else
                                {
                                    cur = rec;
                                }
                            }
                        }

                        oContent += "\n";
                        foreach(var aLine in readGroup.docValues)
                        {
                            parts = aLine.Split(';').ToList();
                            if (parts.Count > 1)
                            {
                                oContent += parts[0] + ";";
                                List<string> colsVals = parts[1].Split(',').ToList();
                                for (int rec = 0; rec < colsVals.Count; ++rec)
                                {
                                    if (rec != cur)
                                    {
                                        oContent += colsVals[rec] + ",";
                                    }
                                }
                            }
                            oContent += "\n";
                        }

                        sw = new StreamWriter(fin.FullName);
                        sw.Write(oContent);
                        sw.Close();
                            
                        break;
                    }
                }

                CompareResultDisplay();
            }
            catch(Exception ex)
            {
                RCLogMessage.Instance().Log(ex.Message);
            }            
        }

        private void IgnoreFileDisplay()
        {
            mLBCompareList.Text = ignoreList;
            mLBCompareList.Show();
            try
            {
                mDGVCompareList.Columns.Clear();
                mDGVCompareList.Rows.Clear();

                int maxCount = 0;
                List<List<string>> contentList = new List<List<string>>();
                Dictionary<string, string> ignoreContent = ReadIgnoreFile();
                foreach (var it in ignoreContent)
                {
                    List<string> singleLine = new List<string>();
                    singleLine.Add(it.Key);
                    singleLine.AddRange(it.Value.Split(','));

                    contentList.Add(singleLine);
                    if (singleLine.Count > maxCount)
                    {
                        maxCount = singleLine.Count;
                    }
                }

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(mDGVCompareList);
                DataGridViewTextBoxCell cellStyle = new DataGridViewTextBoxCell();

                for (int i = 0; i < maxCount; ++i)
                {
                    DataGridViewColumn headerCol = new DataGridViewColumn(cellStyle);
                    mDGVCompareList.Columns.Add(headerCol);
                }

                int lineNum = 0;
                foreach (var words in contentList)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    mDGVCompareList.Rows.Add(newRow);
                    mDGVCompareList.Rows[lineNum].SetValues(words.ToArray());

                    mDGVCompareList.Rows[lineNum].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    mDGVCompareList.Rows[lineNum].DefaultCellStyle.BackColor = Color.Bisque;

                    mDGVCompareList.Rows[lineNum].Cells[0].Style.BackColor = Color.White;

                    lineNum++;
                }
            }

            catch(Exception ex)
            {
                RCLogMessage.Instance().Log(ex.Message);
            }        
        }

        private void removeColumnTSM_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(mTBIgnorePath.Text);
                string ignoreContent = sr.ReadToEnd();
                sr.Close();
                string outStr = "";

                var eachTables = ignoreContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                int x = 0, y = 0;
                foreach (var et in eachTables)
                {
                    var tableContent = et.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (tableContent.Count > 1)
                    {
                        outStr += tableContent[0] + ":";
                        x = 1;
                        var tableIgnores = tableContent[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                        foreach (var ti in tableIgnores)
                        {
                            if (x != mDGVCompareList.SelectedCells[0].ColumnIndex
                                || y != mDGVCompareList.SelectedCells[0].RowIndex)
                            {
                                outStr += ti + ",";
                            }
                            x += 1;
                        }

                        outStr = outStr.Remove(outStr.Length - 1);
                        outStr += "\r\n";
                    }
                    y += 1;
                }

                StreamWriter sw = new StreamWriter(mTBIgnorePath.Text);
                sw.Write(outStr);
                sw.Close();

                IgnoreFileDisplay();
            }

            catch(Exception ex)
            {
                RCLogMessage.Instance().Log(ex.Message);
            }
        }

        private void readmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.Owner = this;
            hf.StartPosition = FormStartPosition.CenterParent;
            hf.ShowInTaskbar = false;
            hf.ShowDialog();
        }

        private void mBtnAdvance_Click(object sender, EventArgs e)
        {
            UDFForm udfForm = new UDFForm();
            udfForm.Owner = this;
            udfForm.StartPosition = FormStartPosition.CenterParent;
            udfForm.ShowInTaskbar = false;
            udfForm.ShowDialog();
        }

        public void SetUDFCompareQueries(string q1, string q2)
        {
            fromUDFCompare = true;
            udfCompareQuery1 = q1;
            udfCompareQuery2 = q2;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (fromUDFCompare == true)
            {
                mProgBar.Show();
                mProgBar.Value = 0;
                mProgBar.Maximum = 5;

                DBCompareCombinationAdvanced();
                fromUDFCompare = false;
                CompareResultDisplay(1);
                lastDisplayType = 1;
            
                mLBCompareList.Show();
                mProgBar.Hide();
            }
        }

        private void mBtnShowCompare_Click(object sender, EventArgs e)
        {
            CompareResultDisplay(lastDisplayType);
        }

        private void mLBLog_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //mLBLog.ClearSelected();
                mLBLogMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void openWorkingDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(createFolderPathName);
            string startCmd = "start .\\working\\" + fileName;
            RCComand.Cmd(startCmd);
        }

        private void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                mProgBar.Value = 0;
                mProgBar.Maximum = fileinfo.Count();
                mProgBar.Show();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);
                    }
                    else if (!i.FullName.Contains(".gitignore"))
                    {
                        File.Delete(i.FullName);
                    }
                    mProgBar.Value += 1;
                }
                mProgBar.Hide();
            }
            catch (Exception e)
            {
                RCLogMessage.Instance().Log(e.Message);
            }
        }

        private void cleanWorkingDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == 
                MessageBox.Show("Are you sure to clean dir?", "Clean", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string deleteCmd = ".\\working\\";
                DelectDir(deleteCmd);
                createFolderPathName = "";
            }
        }

        private void mRBShowCompare_Clicked(object sender, EventArgs e)
        {
            CompareResultDisplay(lastDisplayType);
        }

        private void mRBShowIgnore_Clicked(object sender, EventArgs e)
        {
            IgnoreFileDisplay();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string setStr = "";
            foreach(var x in mLBLog.SelectedItems)
            {
                setStr += (string)x + "\r\n";
            }

            Clipboard.SetDataObject(setStr);
        }

        private void ClearLogTSM_Click(object sender, EventArgs e)
        {
            mLBLog.Items.Clear();
        }

        private void screenCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iWidth = this.Size.Width - 16;
            int iHeight = this.Size.Height - 8;
            Image img = new Bitmap(iWidth, iHeight);            
            Graphics gc = Graphics.FromImage(img);
            gc.CopyFromScreen(new Point(Location.X + 8, Location.Y), new Point(0,0), new Size(iWidth, iHeight));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Types|*.*";
            sfd.FileName = Guid.NewGuid().ToString();
            sfd.DefaultExt = "jpg";
            sfd.AddExtension = true;
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                img.Save(sfd.FileName);
            }
        }

        private void captureToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iWidth = this.Size.Width - 16;
            int iHeight = this.Size.Height - 8;
            Image img = new Bitmap(iWidth, iHeight);
            Graphics gc = Graphics.FromImage(img);
            gc.CopyFromScreen(new Point(Location.X + 8, Location.Y), new Point(0, 0), new Size(iWidth, iHeight));
            Clipboard.SetDataObject(img);
        }

        private void copyTablesDiffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tableName = readResult.GetCellTableName(0,
                mDGVCompareList.SelectedCells[0].RowIndex).Trim();

            DirectoryInfo di = new DirectoryInfo(createFolderPathName);
            FileInfo[] finfo = di.GetFiles();
            foreach(var fin in finfo)
            {
                if (fin.Name.StartsWith("O_" + tableName + "_"))
                {
                    using(StreamReader sr = new StreamReader(fin.FullName))
                    {
                        string result = sr.ReadToEnd();
                        Clipboard.SetDataObject(result);
                        break;
                    }
                }
            }
        }

        private void copyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = mDGVCompareList.SelectedCells[0].Value as string;
            Clipboard.SetDataObject(str);
        }

        private void mTBLeftKey_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                (sender as TextBox).SelectAll();
            });
        }

        private void mTBRightKey_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                (sender as TextBox).SelectAll();
            });
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control == true)
            {
                if (saveToolStripMenuItem.Enabled == true)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
            }

            if (e.KeyCode == Keys.O && e.Control == true)
            {
                openWorkingDirToolStripMenuItem_Click(null, null);
            }

            if (e.KeyCode == Keys.D && e.Control == true)
            {
                cleanWorkingDirToolStripMenuItem_Click(null, null);
            }
            
            if (e.KeyCode == Keys.P && e.Control == true)
            {
                captureToClipboardToolStripMenuItem_Click(null, null);
            }

            if (e.KeyCode == Keys.I && e.Control == true)
            {
                screenCaptureToolStripMenuItem_Click(null, null);
            }

            if (e.KeyCode == Keys.F4 && e.Alt == true)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.F1 && e.Control == true)
            {
                readmeToolStripMenuItem_Click(null, null);
            }

            if (e.KeyCode == Keys.C && e.Alt == true)
            {
                configurationToolStripMenuItem_Click(null, null);
            }

            if (e.KeyCode == Keys.Enter)
            {
                mButtonCompare_Click(null, null);
            }
        }

        private void mPBLogo_Click(object sender, EventArgs e)
        {
            //test MSSQL.
            //MSRstConverter.Convert(@".\abc.txt");
        }
    }
}
