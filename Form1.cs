using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System.IO;

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
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("检测到有修改，是否保存后再退出？","退出程序",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
            if(dialogResult==DialogResult.Yes)
            {
                richEditControl.SaveDocument();
            }
            else if(dialogResult==DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            //if (!hasSaved && richEditControl.CanUndo && DialogResult.Cancel == MessageBox.Show("不保存直接退出？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) {
            //    e.Cancel = true;
            //};
        }

        private void iHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("接下来的操作将会关闭当前文档，是否需要保存文档？", "即将打开帮助文档", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(dialogResult==DialogResult.Yes)
            {
                richEditControl.SaveDocument();
                if (File.Exists("Word文档编辑器使用手册.docx"))
                    richEditControl.LoadDocument("Word文档编辑器使用手册.docx");
                else
                    MessageBox.Show("打开失败，找不到使用手册");
            }
            else if(dialogResult==DialogResult.No)
            {
                if (File.Exists("Word文档编辑器使用手册.docx"))
                    richEditControl.LoadDocument("Word文档编辑器使用手册.docx");
                else
                    MessageBox.Show("打开失败，找不到使用手册");
            }
            
        }

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Word编辑器 - 2143521王劲翔\n支持docx doc rtf txt htm html mht odt xml epub文件", "关于");
        }

        private void fileSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            hasSaved = true;
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}