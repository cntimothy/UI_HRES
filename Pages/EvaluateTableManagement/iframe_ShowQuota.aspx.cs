using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using DataStructure;
using Controls;

namespace HRES.Pages.EvaluateTableManagement
{
    public partial class iframe_ShowQuota : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            if (!IsPostBack)
            {
                Button_Close.OnClientClick = ActiveWindow.GetHideReference();
                bindLevel1ToDropDownList();
            }
        }

        #region Event
        protected void DropDownList1_SelectedChange(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            TextArea1.Text = "";
            bindLevel2ToDropDownList();
        }

        protected void DropDownList2_SelectedChange(object sender, EventArgs e)
        {
            TextArea1.Text = "";
            string level1 = DropDownList1.SelectedValue;
            string level2 = DropDownList2.SelectedValue;
            string exception = "";
            List<string> quota = new List<string>();
            if (EvaluateTableManagementCtrl.GetQuota(ref quota, level1, level2, ref exception))
            {
                TextArea1.Text = quota[0];
                TextArea2.Text = quota[1];
                TextArea3.Text = quota[2];
                TextArea4.Text = quota[3];
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string title = DropDownList1.SelectedValue;
            string quota = "优：" + TextArea1.Text + " 良：" + TextArea2.Text + " 中：" + TextArea3.Text + " 差：" + TextArea4.Text;
            string hiddenMessage = title + "&" + TextArea1.Text + "^" + TextArea2.Text + "^" + TextArea3.Text + "^" + TextArea4.Text;
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(title, quota, hiddenMessage) + ActiveWindow.GetHideReference());
        }
        #endregion

        #region Private Method
        private void bindLevel1ToDropDownList()
        {
            string exception = "";
            List<string> level1s = new List<string>();
            if (EvaluateTableManagementCtrl.GetLevel1(ref level1s, ref exception))
            {
                foreach (string item in level1s)
                {
                    DropDownList1.Items.Add(item, item);
                }
            }
            else
            {
                Alert.ShowInTop("获取指标失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }

        private void bindLevel2ToDropDownList()
        {
            string level1 = DropDownList1.SelectedValue;
            string exception = "";
            List<string> level2s = new List<string>();
            if (EvaluateTableManagementCtrl.GetLevel2(ref level2s, level1, ref exception))
            {
                foreach (string item in level2s)
                {
                    DropDownList2.Items.Add(item, item);
                }
            }
            else
            {
                Alert.ShowInTop("获取指标失败！\n原因：" + exception, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}