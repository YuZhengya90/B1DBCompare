﻿using System;
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
    public partial class ConfigForm : Form
    {
        private bool isInit = true;
        public ConfigForm()
        {
            InitializeComponent();
            InitConfigurationStruct();
            isInit = false;
        }
        
        private void InitConfigurationStruct()
        {
            mCBConfigName.Items.Clear();
            mCBConfigName.Items.AddRange(RCConfigurationList.GetNameList());
            mCBConfigName.Text = RCConfigurationList.GetCurrent().configurationName;
            LoadConfigurationStruct();
        }

        private void LoadConfigurationStruct()
        {
            mTBDesc.Text = RCConfigurationList.GetCurrent().configurationDescription;
            mTBTimeout.Text = RCConfigurationList.GetCurrent().configurationConnectionTimeout.ToString();
            mTBIP.Text = RCConfigurationList.GetCurrent().configurationIPPort;
            mTBSchema.Text = RCConfigurationList.GetCurrent().configurationSchema;
            mTBUserName.Text = RCConfigurationList.GetCurrent().configurationUsername;
            mTBPassword.Text = RCConfigurationList.GetCurrent().configurationPassword;

            if (RCConfigurationList.GetCurrent().configurationDBType == ConfigurationDBType.C_HANA)
            {
                mRBHANA.Checked = true;
            }
            else
            {
                mRBMSSQL.Checked = true;
            }

            mTBExePath.Text = RCConfigurationList.GetCurrent().configurationExePath;
        }

        public void SaveConfigurationStruct()
        {
            //ConfigurationList.GetCurrent().configurationName = mTBConfigName.Text;
            RCConfigurationList.GetCurrent().configurationDescription = mTBDesc.Text;
            RCConfigurationList.GetCurrent().configurationConnectionTimeout = int.Parse(mTBTimeout.Text);
            RCConfigurationList.GetCurrent().configurationIPPort = mTBIP.Text;
            RCConfigurationList.GetCurrent().configurationSchema = mTBSchema.Text;
            RCConfigurationList.GetCurrent().configurationUsername = mTBUserName.Text;
            RCConfigurationList.GetCurrent().configurationPassword = mTBPassword.Text;

            if (mRBHANA.Checked)
            {
                RCConfigurationList.GetCurrent().configurationDBType = ConfigurationDBType.C_HANA;
            }
            else if (mRBMSSQL.Checked)
            {
                RCConfigurationList.GetCurrent().configurationDBType = ConfigurationDBType.C_MSSQL;
            }
            RCConfigurationList.GetCurrent().configurationExePath = mTBExePath.Text;
        }

        private void mRadioMSSQL_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void mRadioHANA_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
        }

        private void mButtonSave_Click(object sender, EventArgs e)
        {
            if (mCBConfigName.DropDownStyle == ComboBoxStyle.Simple)
            {
                if (!File.Exists(mTBExePath.Text))
                {
                    MessageBox.Show(mRBHANA.Checked ? "can't find hdbsql.exe in [" : "can't find sqlcmd.exe in [" + mLBExePath.Text + "]", "Invalid Executable File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (RCConfigurationList.NewAdd(mCBConfigName.Text))
                {  
                    SaveConfigurationStruct();
                    formChanged = false;
                    mCBConfigName.DropDownStyle = ComboBoxStyle.DropDownList;
                    mBtnSave.Text = "SAVE";
                    mBtnCancel.Text = "DISCARD";
                    mBtnNew.Visible = true;
                    mBtnDelete.Visible = true;
                    InitConfigurationStruct();
                }
                else
                {
                    MessageBox.Show("Configuration Name duplicated!", "Invalid Configuration Name", 
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else if (mBtnSave.Text != "OK")
            {
                SaveConfigurationStruct();
                RCConfigurationList.WriteToFile();
                RCConfigurationList.ReSync();
                mBtnSave.Text = "OK";
                mBtnCancel.Text = "CANCEL";
                formChanged = false;
                RCConfigurationList.mListChanged = false;
            }
            else
            {
                this.Dispose();
            }
        }

        private void mButtonCancel_Click(object sender, EventArgs e)
        {
            if (mCBConfigName.DropDownStyle == ComboBoxStyle.Simple)
            {
                mCBConfigName.DropDownStyle = ComboBoxStyle.DropDownList;
                formChanged = false;
                if (RCConfigurationList.mListChanged)
                {
                    mBtnSave.Text = "SAVE";
                    mBtnCancel.Text = "DISCARD";
                }
                else
                {
                    mBtnSave.Text = "OK";
                    mBtnCancel.Text = "CANCEL";
                }
                
                mBtnNew.Visible = true;
                if (RCConfigurationList.GetList().Count > 1)
                {
                    mBtnDelete.Visible = true;
                }
                else
                {
                    mBtnDelete.Visible = false;
                }
                
                InitConfigurationStruct();
            }
            else
            {
                //ConfigurationList.ReSync();
                this.Dispose();
            }
        }

        private void mRadioHANA_Click(object sender, EventArgs e)
        {
            mRBMSSQL.Checked = false;
            mRBHANA.Checked = true;
        }

        private void mRadioMSSQL_Click(object sender, EventArgs e)
        {
            mRBMSSQL.Checked = true;
            mRBHANA.Checked = false;
        }

        private void mBtnBrz_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "Select";
            ofd.Filter = "Executable File|*.exe";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RCConfigurationList.GetCurrent().configurationExePath = ofd.FileName;
            }
        }

        private void ConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mButtonCancel_Click(null, null);
            }
        }

        private void mCBConfigName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formChanged)
            {
                if (DialogResult.Yes == MessageBox.Show("Save Changed Values ?", "Configuration Changed",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    SaveConfigurationStruct();
                }
            }

            RCConfigurationList.SetCurrent(mCBConfigName.Text);
            LoadConfigurationStruct();
            formChanged = false;
        }

        private void mBtnNew_Click(object sender, EventArgs e)
        {
            if (formChanged)
            {
                if (DialogResult.Yes == MessageBox.Show("Save Changed Values ?", "Configuration Changed",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    SaveConfigurationStruct();
                }
            }

            mCBConfigName.DropDownStyle = ComboBoxStyle.Simple;
            mCBConfigName.Text = "";
            //mTBDesc.Text = "";
            //mTBIP.Text = "";
            //mTBPassword.Text = "";
            //mTBSchema.Text = "";
            //mTBUserName.Text = "";

            mBtnSave.Text = "SAVE NEW";
            mBtnCancel.Text = "EXIT NEW";
            mBtnNew.Visible = false;
            mBtnDelete.Visible = false;
        }

        private void mBtnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Sure to Delete ?", "Configuration Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                RCConfigurationList.RemoveCurrent();
                InitConfigurationStruct();
                
            }

            if (RCConfigurationList.GetList().Count > 1)
            {
                mBtnDelete.Visible = true;
            }
            else
            {
                mBtnDelete.Visible = false;
            }

        }

        private bool formChanged = false;

        private void mTBDesc_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mTBIP_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mTBUserName_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mTBSchema_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mTBPassword_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mTBTimeout_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mTBExePath_TextChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
        }

        private void mRBHANA_CheckedChanged(object sender, EventArgs e)
        {
            if (!isInit && mCBConfigName.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                mBtnSave.Text = "SAVE";
                mBtnCancel.Text = "DISCARD";
                formChanged = true;
            }
            else
            {
                if (mRBHANA.Checked == true)
                    mTBExePath.Text = RCConfigurationStruct.hdbsqlPathDefault;
                else
                    mTBExePath.Text = RCConfigurationStruct.SqlcmdPathDefault;
            }
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RCConfigurationList.ReSync();
        }
    }
}
