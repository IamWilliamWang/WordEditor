using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;


namespace WordEditor
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private static bool hasSaved = false;

        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            InitializeRichEditControl();
            ribbonControl.SelectedPage = homeRibbonPage1;
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        void InitializeRichEditControl()
        {

        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!hasSaved && richEditControl.CanUndo && DialogResult.Cancel == MessageBox.Show("不保存直接退出？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) {
                e.Cancel = true;
            };
        }

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Word编辑器 - 2143521王劲翔\n支持docx doc rtf txt htm html mht odt xml epub文件", "关于");
        }

        private void fileSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            hasSaved = true;
        }

        private void fileOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}